using GeoLearn.Application.Application.DTO;

namespace GeoLearn.Application.Application;

public interface IAplicAuth
{
    Task<int> RegisterUser(RegisterUserDto registerUserDto);
    Task<LoginUserViewModel> LoginUser(LoginUserDto loginUserDto);
}