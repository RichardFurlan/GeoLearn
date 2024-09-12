using GeoLearn.Application.Auth;
using GeoLearn.Application.Auth.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
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
    public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
    {
        try
        {
            var result = await _aplicAuth.RegisterUser(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
    {
        try
        {
           var result = await _aplicAuth.LoginUser(dto);
           if (!result.IsSuccess)
           {
               return BadRequest(result.Message);
           }

           return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}