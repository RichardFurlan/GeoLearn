using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Infra.Persistence.Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly GeoLearnDbContext _dbContext;

    public QuizRepository(GeoLearnDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Quiz?> GetDetailsByIdAsync(int id)
    {
        return await _dbContext.Quizzes
            .SingleOrDefaultAsync(q => q.Id == id);
    }
    
    public async Task UpdateAsync(Quiz quiz)
    {
        _dbContext.Quizzes.Update(quiz);
        await _dbContext.SaveChangesAsync();
    }
}