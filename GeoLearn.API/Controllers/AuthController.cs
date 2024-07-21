using GeoLearn.Application.Application;
using GeoLearn.Application.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    #region ctor
    private readonly IAplicAuth _aplicAuth;

    public AuthController(IAplicAuth aplicAuth)
    {
        _aplicAuth = aplicAuth;
    }
    
    #endregion
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        try
        {
            var userId = await _aplicAuth.RegisterUser(dto);
            return Ok(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        try
        {
           var loginUserViewModel = await _aplicAuth.LoginUser(dto);
           if (loginUserViewModel == null)
           {
               BadRequest();
           }

           return Ok(loginUserViewModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}