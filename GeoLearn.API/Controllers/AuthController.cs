using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register()
    {
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        return Ok();
    }
}