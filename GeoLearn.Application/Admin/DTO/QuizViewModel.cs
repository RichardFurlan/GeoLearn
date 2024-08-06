using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Admin.DTO;

public record QuizViewModel(string Title, string Description, EnumCategoriaQuiz Category);