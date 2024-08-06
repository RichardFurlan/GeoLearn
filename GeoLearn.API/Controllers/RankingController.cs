using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RankingController : ControllerBase
{
    [HttpGet()]
    public IActionResult GetRanking()
    {
        return Ok();
    }
}