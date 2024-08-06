using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record CreateQuizDTO
{
    public string Title { get; init; }
    public string Description { get; init; }
    public EnumCategoriaQuiz Category  { get; init; }
};