using GeoLearn.Application.Application.Admin.DTO;

namespace GeoLearn.Application.Application.Admin;

public interface IAplicAdmin
{
    Task<List<QuizViewModel>> GetAllQuizzes();
    Task<QuizViewModel> GetQuiz(int id);
    Task<QuizQuestionViewModel> GetQuizQuestion(int id);
    Task<int> CreateQuiz(CreateQuizDTO dto);
    Task<int> CreateQuizQuestion(CreateQuizQuestionDTO dto);
    Task UpdateQuiz(int id, UpdateQuizDTO dto);
    Task InactivateQuiz(int id);
    
    Task<List<UserViewModel>> GetAllUsers();
    Task<UserViewModel> GetUser(int id);
    Task<int> CreateUser(CreateUserDTO dto);
    Task UpdateUser(UpdateUserDTO dto);
    Task InactivateUser(int id);
}