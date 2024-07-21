using GeoLearn.Domain.Entities;

namespace GeoLearn.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
}