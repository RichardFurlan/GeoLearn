using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record CreateQuizQuestionDto
{
    public int QuizId { get; init; }
    public string QuizQuestion { get; init; }
    public EnumNivelDificuldade Dificuldade { get; init; }
    public int Experience { get; init; }
    public List<string> Options { get; init; }
    public string CorrectAnswer { get; init; }
    
    
};