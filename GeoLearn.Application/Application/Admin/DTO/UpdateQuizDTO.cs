using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record UpdateQuizDTO
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public EnumCategoriaQuiz Category  { get; init; }
};