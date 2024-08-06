using GeoLearn.Domain.Entities;

namespace GeoLearn.Domain.Repositories;

public interface IQuizRepository
{
    Task<Quiz?> GetDetailsByIdAsync(int id);
    IQueryable<Quiz?> GetAllQuizzes();
    Task UpdateAsync(Quiz quiz);
}