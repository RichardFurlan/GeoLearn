using GeoLearn.Application.Application.Admin.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using GeoLearn.Infra.IAServices;
using GeoLearn.Infra.Persistence;

namespace GeoLearn.Application.Application.Admin;

public class AplicAdmin : IAplicAdmin
{
    private readonly IOpenAIService _aiService;
    private readonly GeoLearnDbContext _dbContext;
    private readonly IQuizRepository _quizRepository;
    public AplicAdmin(IOpenAIService aiService, GeoLearnDbContext dbContext, IQuizRepository quizRepository)
    {
        _aiService = aiService;
        _dbContext = dbContext;
        _quizRepository = quizRepository;
    }
    public async Task<QuizGenerateAIDtoViewModel> GenerateQuizQuestionAndAnswer(QuizGenerateAIDto dto)
    {
        string categoria;
        string nivelDificuldade;
        switch (dto.Category)
        {
            case EnumCategoriaQuiz.Capitais: 
                categoria = "capitais";
                break;
            case EnumCategoriaQuiz.Continentes:
                categoria = "continentes";
                break;
            case EnumCategoriaQuiz.Países:
                categoria = "países";
                break;
            default:
                categoria = "geografia em geral";
                break;
        }

        switch (dto.Dificuldade)
        {
            case EnumNivelDificuldade.Fácil:
                nivelDificuldade = "fácil";
                break;
            case EnumNivelDificuldade.Médio:
                nivelDificuldade = "médio";
                break;
            case EnumNivelDificuldade.Díficil:
                nivelDificuldade = "díficil";
                break;
            default:
                nivelDificuldade = "médio";
                break;
        }
        
        var questionResponde = await _aiService.GenerateText(categoria, dto.Suggestion, nivelDificuldade);

        var viewModel = new QuizGenerateAIDtoViewModel(questionResponde.Question, questionResponde.CorrectAnswer, questionResponde.IncorrectAnswers);

        return viewModel;
    }

    public async Task<int> CreateQuizAndAnswer(CreateQuizQuestionDto dto)
    {
        var quiz = await _quizRepository.GetDetailsByIdAsync(dto.QuizId);
        if (quiz == null)
        {
            throw new Exception("Quiz not found");
        }
        
        var quizQuestion = new QuizQuestion(dto.QuizQuestion, dto.Dificuldade, dto.Experience);

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
}