using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Admin.DTO;

public record CreateQuizQuestionDTO
{
    public int QuizId { get; init; }
    public string QuizQuestion { get; init; }
    public EnumNivelDificuldade Difficulty { get; init; }
    public int Experience { get; init; }
    public List<string> Options { get; init; }
    public string CorrectAnswer { get; init; }
    
    
};