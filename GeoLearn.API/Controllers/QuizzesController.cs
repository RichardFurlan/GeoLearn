using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/quizzes")]
public class QuizzesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllQuizzes()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetQuiz(int id)
    {
        return Ok();
    }

    [HttpPost("{id}/answer")]
    public IActionResult SubmitQuizAnswers()
    {
        return Ok();
    }
}