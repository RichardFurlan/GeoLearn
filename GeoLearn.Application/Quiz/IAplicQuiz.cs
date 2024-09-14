using GeoLearn.Application.DTO;
using GeoLearn.Application.Quiz.DTO;

namespace GeoLearn.Application.Quiz;

public interface IAplicQuiz
{
    Task<ResultViewModel<List<QuizViewModel>>> GetAllQuizzes();
    Task<ResultViewModel<QuizDetailsViewModel>> GetQuizById(int id);
    Task<ResultViewModel<SubmitAnswerResultViewModel>> SubmitAnswer(SubmitAnswerDTO dto);
}