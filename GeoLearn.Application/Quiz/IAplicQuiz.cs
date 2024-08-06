using GeoLearn.Application.Quiz.DTO;

namespace GeoLearn.Application.Quiz;

public interface IAplicQuiz
{
    Task<List<QuizViewModel>> GetAllQuizzes();
    Task<QuizDetailsViewModel> GetQuizById(int id);
    Task<SubmitAnswerResultViewModel> SubmitAnswer(SubmitAnswerDTO dto);
}