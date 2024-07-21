using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record QuizGenerateAIDto
{
    public string Suggestion { get; init; }
    public EnumCategoriaQuiz Category { get; init; }
    public EnumNivelDificuldade Dificuldade { get; init; }
};