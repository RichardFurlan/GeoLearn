using GeoLearn.Application;
using GeoLearn.Application.Admin;
using GeoLearn.Application.Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAplicAdmin _aplicAdmin;
    public AdminController(IAplicAdmin aplicAdmin)
    {
        _aplicAdmin = aplicAdmin;
    }
    
    [HttpGet("quizzes")]
    public async Task<IActionResult> GetAllQuizzes()
    {
        try
        {
            var quizDetails = await _aplicAdmin.GetAllQuizzes();
            return Ok(quizDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("quizzes/{id}")]
    public async Task<IActionResult> GetQuiz(int id)
    {
        try
        {
            var quizDetails = await _aplicAdmin.GetQuiz(id);
            return Ok(quizDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("quizzes/questions/{id}")]
    public async Task<IActionResult> GetQuizQuestion(int id)
    {
        try
        {
            var quizQustionDetails = await _aplicAdmin.GetQuizQuestion(id);
            return Ok(quizQustionDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("quizzes")]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDTO dto)
    {
        try
        {
            var quizId = await _aplicAdmin.CreateQuiz(dto);
            return Ok(quizId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost("quizzes/questions")]
    public async Task<IActionResult> CreateQuizQuestion([FromBody] CreateQuizQuestionDTO dto)
    {
        try
        {
            var quizQuestionId = await _aplicAdmin.CreateQuizQuestion(dto);
            return Ok(quizQuestionId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("quizzes/{id}")]
    public async Task<IActionResult> UpdateQuiz(UpdateQuizDTO dto)
    {
        try
        {
           await _aplicAdmin.UpdateQuiz(dto.Id, dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("quizzes/{id}")]
    public async Task<IActionResult> InactivateQuiz(int id)
    {
        try
        {
            await _aplicAdmin.InactivateQuiz(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var usersViewModel = await _aplicAdmin.GetAllUsers();

            return Ok(usersViewModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var userViewModel = await _aplicAdmin.GetUser(id);
            return Ok(userViewModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
    {
        try
        {
            var userId = await _aplicAdmin.CreateUser(dto);
            return Ok(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("users")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO dto)
    {
        try
        {
            await _aplicAdmin.UpdateUser(dto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> InactivateUser(int id)
    {
        try
        {
            await _aplicAdmin.InactivateUser(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}