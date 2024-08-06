using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Admin.DTO;

public record CreateQuizDTO
{
    public string Title { get; init; }
    public string Description { get; init; }
    public EnumCategoriaQuiz Category  { get; init; }
};