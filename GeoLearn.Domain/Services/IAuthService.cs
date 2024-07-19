namespace GeoLearn.Domain.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role);
}