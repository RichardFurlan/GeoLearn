using GeoLearn.Domain.Entities;

namespace GeoLearn.Domain.Repositories;

public interface IQuizRepository
{
    Task<Quiz?> GetDetailsByIdAsync(int id);
    Task UpdateAsync(Quiz quiz);
}