using GeoLearn.Application.Application.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Infrastructure.Persistence;

namespace GeoLearn.Application.Application;

public class AplicAuth : IAplicAuth
{
    private readonly GeoLearnDbContext _dbContext;
    
    public AplicAuth(GeoLearnDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> RegisterUser(RegisterUserDto registerUserDto)
    {
        ValidarSenha(registerUserDto.Password, registerUserDto.PasswordConfirm);
        
        var user = new User(
            registerUserDto.FirstName,
            registerUserDto.LastName,
            registerUserDto.Email,
            registerUserDto.Password
            );

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    private void ValidarSenha(string password, string passwordConfirm)
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

    public Task LoginUser(LoginUserDto loginUserDto)
    {
        throw new NotImplementedException();
    }
}