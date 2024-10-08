using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUserProfile()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserProfile(int id)
    {
        return Ok();
    }
}