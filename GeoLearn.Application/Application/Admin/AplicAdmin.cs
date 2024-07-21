using GeoLearn.Application.Application.Admin.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Infrastructure.IAServices;

namespace GeoLearn.Application.Application.Admin;

public class AplicAdmin : IAplicAdmin
{
    private readonly IOpenAIService _aiService;
    public AplicAdmin(IOpenAIService aiService)
    {
        _aiService = aiService;
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
}