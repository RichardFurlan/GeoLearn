using GeoLearn.Application.Application.DTO;

namespace GeoLearn.Application.Application;

public interface IAplicAuth
{
    Task<int> RegisterUser(RegisterUserDto registerUserDto);
    Task LoginUser(LoginUserDto loginUserDto);
}