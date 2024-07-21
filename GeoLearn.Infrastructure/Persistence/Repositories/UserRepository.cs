using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GeoLearn.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GeoLearnDbContext _dbContext;
    public UserRepository(GeoLearnDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _dbContext
            .Users
            .SingleOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
    }
}