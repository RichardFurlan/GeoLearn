using GeoLearn.Application.Quiz;
using GeoLearn.Application.Quiz.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GeoLearn.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QuizzesController : ControllerBase
{
    private readonly IAplicQuiz _aplicQuiz;
    public QuizzesController(IAplicQuiz aplicQuiz)
    {
        _aplicQuiz = aplicQuiz;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllQuizzes()
    {
        var result = await _aplicQuiz.GetAllQuizzes();
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuiz(int id)
    {
        var result =  await _aplicQuiz.GetQuizById(id);
        return Ok(result);
    }

    [HttpPost("{id}/answer")]
    public async Task<IActionResult> SubmitQuizAnswers(SubmitAnswerDTO dto)
    {
        var result = await _aplicQuiz.SubmitAnswer(dto);
        return Ok(result);
    }
}