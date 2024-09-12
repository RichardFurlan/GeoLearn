using GeoLearn.Application.Admin.DTO;
using GeoLearn.Application.DTO;

namespace GeoLearn.Application.Admin;

public interface IAplicAdmin
{
    Task<ResultViewModel<List<QuizViewModel>>> GetAllQuizzes();
    Task<ResultViewModel<QuizViewModel>> GetQuiz(int id);
    Task<ResultViewModel<QuizQuestionViewModel>> GetQuizQuestion(int id);
    Task<ResultViewModel<int>> CreateQuiz(CreateQuizDTO dto);
    Task<ResultViewModel<int>> CreateQuizQuestion(CreateQuizQuestionDTO dto);
    Task<ResultViewModel> UpdateQuiz(int id, UpdateQuizDTO dto);
    Task<ResultViewModel> InactivateQuiz(int id);
    
    Task<ResultViewModel<List<UserViewModel>>> GetAllUsers();
    Task<ResultViewModel<UserViewModel>> GetUser(int id);
    Task<ResultViewModel<int>> CreateUser(CreateUserDTO dto);
    Task<ResultViewModel> UpdateUser(UpdateUserDTO dto);
    Task<ResultViewModel> InactivateUser(int id);
}