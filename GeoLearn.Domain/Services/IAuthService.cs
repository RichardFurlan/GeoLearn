namespace GeoLearn.Domain.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email);
    string ComputeSha256Hash(string password);
    void ValidarSenha(string password, string passwordConfirm);
}