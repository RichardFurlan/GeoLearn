using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;

namespace GeoLearn.Infra.Persistence.Repositories;

public class QuizAnswerRepository : IQuizAnswerRepository
{
    private readonly GeoLearnDbContext _dbContext;

    public QuizAnswerRepository(GeoLearnDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SaveAnswerAsync(QuizAnswer quizAnswer)
    {
        await _dbContext.QuizAnswers.AddAsync(quizAnswer);
        await _dbContext.SaveChangesAsync();
    }
}