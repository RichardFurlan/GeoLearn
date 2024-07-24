using GeoLearn.Application.Application.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using GeoLearn.Domain.Services;
using GeoLearn.Infra.Persistence;

namespace GeoLearn.Application.Application.Auth;

public class AplicAuth : IAplicAuth
{
    private readonly IUserRepository _userRepository;
    private readonly GeoLearnDbContext _dbContext;
    private readonly IAuthService _authService;
    
    public AplicAuth(IUserRepository userRepository, IAuthService authService, GeoLearnDbContext dbContext)
    {
        _userRepository = userRepository;
        _authService = authService;
        _dbContext = dbContext;
    }
    public async Task<int> RegisterUser(RegisterUserDto registerUserDto)
    {
        ValidarSenha(registerUserDto.Password, registerUserDto.PasswordConfirm);
        var passwordHash = _authService.ComputeSha256Hash(registerUserDto.Password);
        
        var user = new User(
            registerUserDto.FirstName,
            registerUserDto.LastName,
            registerUserDto.Email,
            passwordHash
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

    public async Task<LoginUserViewModel> LoginUser(LoginUserDto loginUserDto)
    {
        var passwordHash = _authService.ComputeSha256Hash(loginUserDto.Password);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginUserDto.Email, passwordHash);
        
        if (user == null)
        {
            return null;
        }

        var token = _authService.GenerateJwtToken(user.Email);

        return new LoginUserViewModel(user.Email, token);
    }
}