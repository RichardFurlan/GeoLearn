using GeoLearn.Application.Auth.DTO;
using GeoLearn.Application.DTO;

namespace GeoLearn.Application.Auth;

public interface IAplicAuth
{
    Task<ResultViewModel<int>> RegisterUser(RegisterUserDTO registerUserDto);
    Task<ResultViewModel<LoginUserViewModel>> LoginUser(LoginUserDTO loginUserDto);
}