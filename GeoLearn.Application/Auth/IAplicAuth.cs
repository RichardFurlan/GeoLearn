using GeoLearn.Application.Auth.DTO;

namespace GeoLearn.Application.Auth;

public interface IAplicAuth
{
    Task<int> RegisterUser(RegisterUserDTO registerUserDto);
    Task<LoginUserViewModel> LoginUser(LoginUserDTO loginUserDto);
}