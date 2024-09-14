using System.Transactions;
using GeoLearn.Application.DTO;
using GeoLearn.Application.Quiz.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Application.Quiz;

public class AplicQuiz : IAplicQuiz
{
    private readonly IQuizRepository _quizRepository;
    private readonly IUserRepository _userRepository;
    private readonly IQuizAnswerRepository _quizAnswerRepository;

    public AplicQuiz(IQuizRepository quizRepository, IUserRepository userRepository, IQuizAnswerRepository quizAnswerRepository)
    {
        _quizRepository = quizRepository;
        _userRepository = userRepository;
        _quizAnswerRepository = quizAnswerRepository;
    }

    public async Task<ResultViewModel<List<QuizViewModel>>> GetAllQuizzes()
    {
        var quizzes = await _quizRepository.GetAllQuizzes().ToListAsync();
        
        var quizzesViewModel = quizzes.Select(q => new QuizViewModel(
            q.Title,
            q.Description,
            q.Category
        )).ToList();
        
        return ResultViewModel<List<QuizViewModel>>.Success(quizzesViewModel);
    }

    public async Task<ResultViewModel<QuizDetailsViewModel>> GetQuizById(int id)
    {
        var quiz = await _quizRepository.GetDetailsByIdAsync(id);
        
        if (quiz == null)
        {
            throw new KeyNotFoundException("Quiz not found");
        }

        var quizDetailsViewModel = new QuizDetailsViewModel(
            quiz.Title,
            quiz.Description,
            quiz.Category,
            quiz.Questions.Select(qq => new QuizQuestionViewModel(
                qq.QuestionText,
                qq.Difficulty,
                qq.ExperiencePoints,
                qq.Options.Select(qo => new QuizOptionViewModel(
                    qo.OptionText,
                    qo.IsCorrect
                )).ToList()
            )).ToList()
        );

        return ResultViewModel<QuizDetailsViewModel>.Success(quizDetailsViewModel);
    }

    public async Task<ResultViewModel<SubmitAnswerResultViewModel>> SubmitAnswer(SubmitAnswerDTO dto)
    {
        if (dto.SelectedOptionIds == null || !dto.SelectedOptionIds.Any())
        {
            throw new ArgumentException("No options selected");
        }
        
        if (dto.SelectedOptionIds.Any(id => id == null))
        {
            throw new ArgumentException("One or more selected option IDs are null");
        }
        
        var quiz = await _quizRepository.GetDetailsByIdAsync(dto.QuizId);
        if (quiz == null)
        {
            throw new KeyNotFoundException("Quiz not found");
        }
        
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var selectedOptions = quiz.Questions
            .SelectMany(q => q.Options)
            .Where(qo => dto.SelectedOptionIds.Contains(qo.Id))
            .ToList();
        
        var totalPointsWon = selectedOptions
            .Sum(o => o.IsCorrect ? o.QuizQuestion.ExperiencePoints : 0);

        var questionsResult = quiz.Questions.Select(q => new QuizQuestionResultViewModel(
            q.QuestionText,
            q.Difficulty,
            q.ExperiencePoints,
            selectedOptions
                .Where(o => o.QuizQuestionId == q.Id)
                .Select(o => new QuizOptionResultViewModel(o.OptionText, o.IsCorrect))
                .FirstOrDefault() ?? new QuizOptionResultViewModel(string.Empty, false)
        )).ToList();

        var quizAnswer = new QuizAnswer(dto.UserId, dto.QuizId);
        foreach (var option in selectedOptions)
        {
            var quizOptionAnswer = new QuizOptionAnswer(quizAnswer.Id, option.Id);
            quizAnswer.AddOptionAnswer(quizOptionAnswer);
        }
        
        user.AddPointsForUser(totalPointsWon);

        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _userRepository.UpdateAsync(user);
            await _quizAnswerRepository.SaveAnswerAsync(quizAnswer);
            transaction.Complete();
        }

        return ResultViewModel<SubmitAnswerResultViewModel>.Success(new SubmitAnswerResultViewModel(
            totalPointsWon,
            questionsResult
        ));
    }
}