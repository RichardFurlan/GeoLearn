using GeoLearn.Application.Application.Admin.DTO;

namespace GeoLearn.Application.Application.Admin;

public interface IAplicAdmin
{
    Task<QuizGenerateAIDtoViewModel> GenerateQuizQuestionAndAnswer(QuizGenerateAIDto dto);
    Task<int> CreateQuizAndAnswer(CreateQuizQuestionDto dto);
}