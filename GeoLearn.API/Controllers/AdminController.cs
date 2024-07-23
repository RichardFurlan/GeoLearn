using GeoLearn.Application.Application.Admin;
using GeoLearn.Application.Application.Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IAplicAdmin _aplicAdmin;
    public AdminController(IAplicAdmin aplicAdmin)
    {
        _aplicAdmin = aplicAdmin;
    }
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
    
    [HttpPost("quizzes/generate-qa")]
    public async Task<IActionResult> GenerateQuestionAndAnswers([FromBody] QuizGenerateAIDto dto)
    {
        try
        {
            var viewModel = await _aplicAdmin.GenerateQuizQuestionAndAnswer(dto);
            return Ok(viewModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("quizzes")]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizQuestionDto dto)
    {
        try
        {
            var quizQuestionId = await _aplicAdmin.CreateQuizAndAnswer(dto);
            return Ok(quizQuestionId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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