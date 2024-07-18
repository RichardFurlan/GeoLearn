using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api")]
public class RankingController : ControllerBase
{
    [HttpGet("ranking")]
    public IActionResult GetRanking()
    {
        return Ok();
    }
}