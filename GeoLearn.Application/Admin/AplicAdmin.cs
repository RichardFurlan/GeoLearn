using GeoLearn.Application.Admin.DTO;
using GeoLearn.Application.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using GeoLearn.Domain.Services;
using GeoLearn.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Application.Admin;

public class AplicAdmin : IAplicAdmin
{
    #region ctor
    private readonly GeoLearnDbContext _dbContext;
    private readonly IQuizRepository _quizRepository;
    private readonly IAuthService _authService;
    public AplicAdmin(GeoLearnDbContext dbContext, IQuizRepository quizRepository, IAuthService authService)
    {
        _dbContext = dbContext;
        _quizRepository = quizRepository;
        _authService = authService;
    }
    #endregion
    
    #region QUIZ

    #region CreateQuizQuestion
    public async Task<int> CreateQuizQuestion(CreateQuizQuestionDTO dto)
    {
        var quiz = await _quizRepository.GetDetailsByIdAsync(dto.QuizId);
        if (quiz == null)
        {
            throw new Exception("Quiz not found");
        }
        
        var quizQuestion = new QuizQuestion(dto.QuizQuestion, dto.Difficulty, dto.Experience);

        foreach (var option in dto.Options)
        {
            bool isCorrect = option == dto.CorrectAnswer;
            var quizOption = new QuizOption(quizQuestion.Id, option, isCorrect);
            quizQuestion.AddOption(quizOption);
        }
        
        quiz.AddQuestion(quizQuestion);
        
        _dbContext.QuizQuestions.Add(quizQuestion);
        await _dbContext.SaveChangesAsync();
        
        return quizQuestion.Id;
    }
    #endregion

    #region CreateQuiz
    public async Task<int> CreateQuiz(CreateQuizDTO dto)
    {
        var quiz = new Domain.Entities.Quiz(dto.Title, dto.Description, dto.Category);
        
        await _dbContext.Quizzes.AddAsync(quiz);
        await _dbContext.SaveChangesAsync();

        return quiz.Id;
    }
    #endregion

    #region GetAllQuizzes
    public async Task<ResultViewModel<List<QuizViewModel>>> GetAllQuizzes()
    {
        var quizzes = await _dbContext.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Options)
            .ToListAsync();
        
        var quizzesViewModel = quizzes.Select(q => new QuizViewModel(
            q.Title,
            q.Description,
            q.Category
        )).ToList();
        
        return ResultViewModel<List<QuizViewModel>>.Success(quizzesViewModel);
    }
    

    #endregion
    
    #region GetQuiz
    public async Task<QuizViewModel> GetQuiz(int id)
    {
        var quiz = await _dbContext.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Options)
            .SingleOrDefaultAsync(q => q.Id == id);
        
        if (quiz == null)
        {
            throw new KeyNotFoundException("Quiz not found.");
        }

        var quizViewModel = new QuizViewModel(
            quiz.Title,
            quiz.Description,
            quiz.Category
        );

        return quizViewModel;
    }
    #endregion

    #region GetQuizQuestion
    public async Task<QuizQuestionViewModel> GetQuizQuestion(int id)
    {
        var quizQuestion = await _dbContext.QuizQuestions
            .Include(qq => qq.Options)
            .SingleOrDefaultAsync(qq => qq.Id == id);

        if (quizQuestion == null)
        {
            throw new KeyNotFoundException("Quiz Question not found.");
        }
        
        var quizQuestionViewModel = new QuizQuestionViewModel(
            quizQuestion.QuestionText,
            quizQuestion.Difficulty,
            quizQuestion.ExperiencePoints,
            quizQuestion.Options.Select(qq => new QuizOptionViewModel(
                qq.OptionText,
                qq.IsCorrect
            )).ToList()
        );

        return quizQuestionViewModel;
    }
    

    #endregion

    #region UpdateQuiz
    public async Task UpdateQuiz(int id, UpdateQuizDTO dto)
    {
        var quiz = await _quizRepository.GetDetailsByIdAsync(id);

        if (quiz == null)
        {
            throw new KeyNotFoundException("Quiz not found.");
        }
        
        quiz.UpdateDetails(dto.Title, dto.Description, dto.Category);

        await _quizRepository.UpdateAsync(quiz);
    }
    #endregion
    
    #region InactivateQuiz
    public async Task InactivateQuiz(int id)
    {
        var quiz = await _quizRepository.GetDetailsByIdAsync(id);
        if (quiz == null)
        {
            throw new KeyNotFoundException("Quiz not found.");
        }

        quiz.Inativar();

        await _quizRepository.UpdateAsync(quiz);
    }
    

    #endregion


    #endregion

    #region USER

    #region GetAllUsers
    public async Task<List<UserViewModel>> GetAllUsers()
    {
        var user = await _dbContext.Users.
            Include(user => user.Adress)
            .ToListAsync();

        var userViewModel = user.Select(u => new UserViewModel(
            u.FirstName,
            u.LastName,
            u.Email,
            u.Biography,
            u.PersonImage,
            u.Phone,
            u.Adress
        )).ToList();

        return userViewModel;
    }
    #endregion
    
    #region GetUser
    public async Task<UserViewModel> GetUser(int id)
    {
        var user = await _dbContext.Users
            .Include(u => u.Adress)
            .SingleOrDefaultAsync(u => u.Id == id);
        
        if (user == null)
        {
            throw new KeyNotFoundException("Quiz Question not found.");
        }

        var userViewModel = new UserViewModel(user.FirstName, user.LastName, user.Email, user.Biography,
            user.PersonImage, user.Phone, user.Adress);
        
        return userViewModel;
    }
    #endregion

    #region CreateUser
    public async Task<int> CreateUser(CreateUserDTO dto)
    {
        _authService.ValidarSenha(dto.Password, dto.PasswordConfirm);
        var passwordHash = _authService.ComputeSha256Hash(dto.Password);
        
        var user = new User(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            passwordHash
        );

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }
    #endregion

    #region UpdateUser
    public async Task UpdateUser(UpdateUserDTO dto)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == dto.Id);
        
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }
        
        user.UpdateDetails(
            dto.FirstName, 
            dto.LastName, 
            dto.Email, 
            dto.Biography,
            dto.PersonImage, 
            dto.Phone, 
            dto.CPF,
            dto.Adress);
        
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
    
    #region InactivateUser
    public async Task InactivateUser(int id)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        user.Inativar();

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
    
    #endregion
    
}