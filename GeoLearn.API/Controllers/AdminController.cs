using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    [HttpGet("quizzes")]
    public IActionResult GetAllQuizzes()
    {
        return Ok();
    }

    [HttpGet("quizzes/{id}")]
    public IActionResult GetQuiz(int id)
    {
        return Ok();
    }

    [HttpPost("quizzes")]
    public IActionResult CreateQuiz()
    {
        return Ok();
    }

    [HttpPut("quizzes/{id}")]
    public IActionResult UpdateQuiz(int id)
    {
        return Ok();
    }

    [HttpDelete("quizzes/{id}")]
    public IActionResult InactivateQuiz(int id)
    {
        return Ok();
    }

    [HttpGet("users")]
    public IActionResult GetAllUsers()
    {
        return Ok();
    }

    [HttpGet("users/{id}")]
    public IActionResult GetUser(int id)
    {
        return Ok();
    }

    [HttpPost("users")]
    public IActionResult CreateUser()
    {
        return Ok();
    }

    [HttpPut("users/{id}")]
    public IActionResult UpdateUser(int id)
    {
        return Ok();
    }

    [HttpDelete("users/{id}")]
    public IActionResult InactivateUser(int id)
    {
        return Ok();
    }
}