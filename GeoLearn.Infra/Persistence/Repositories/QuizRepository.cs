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
            .Include(q => q.Questions)
            .ThenInclude(qq => qq.Options)
            .SingleOrDefaultAsync(q => q.Id == id);
    }

    public IQueryable<Quiz?> GetAllQuizzes()
    {
        return _dbContext.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Options);
    }

    public async Task UpdateAsync(Quiz quiz)
    {
        _dbContext.Quizzes.Update(quiz);
        await _dbContext.SaveChangesAsync();
    }
}