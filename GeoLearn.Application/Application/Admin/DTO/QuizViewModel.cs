using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record QuizViewModel(string Title, string Description, EnumCategoriaQuiz Category);