using GeoLearn.Application.Auth.DTO;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Repositories;
using GeoLearn.Domain.Services;
using GeoLearn.Infra.Persistence;

namespace GeoLearn.Application.Auth;

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
    public async Task<int> RegisterUser(RegisterUserDTO registerUserDto)
    {
        _authService.ValidarSenha(registerUserDto.Password, registerUserDto.PasswordConfirm);
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
    
    public async Task<LoginUserViewModel> LoginUser(LoginUserDTO loginUserDto)
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