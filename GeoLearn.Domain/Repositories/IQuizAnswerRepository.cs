using GeoLearn.Domain.Entities;

namespace GeoLearn.Domain.Repositories;

public interface IQuizAnswerRepository
{
    Task SaveAnswerAsync(QuizAnswer quizAnswer);
}