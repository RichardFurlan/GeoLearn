using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using GeoLearn.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GeoLearn.Infra.AuthServices;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJwtToken(string email)
    {
        var issuer = _configuration["Jtw:Issuer"];
        var audience = _configuration["Jtw:Audience"];
        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        

        var token = new JwtSecurityToken(
            issuer: issuer, 
            audience: audience, 
            expires: DateTime.Now.AddHours(8), 
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;

    }

    public string ComputeSha256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - retorna byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Converte byte array para string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2")); // X2 faz com que seja convertido em representação hexadecimal
            }

            return builder.ToString();
        }
    }
    
    public void ValidarSenha(string password, string passwordConfirm)
    {
        if (password != passwordConfirm)
        {
            throw new ArgumentException("As senhas não são idênticas");
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("A senha não pode estar em branco.");
        }

        if (password.Length < 6)
        {
            throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
        }

        if (!password.Any(char.IsDigit))
        {
            throw new ArgumentException("A senha deve conter pelo menos um número");
        }
        
        if (!password.Any(char.IsLetter))
        {
            throw new ArgumentException("A senha deve conter pelo menos uma letra.");
        }
    }
    
}