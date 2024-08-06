using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Quiz.DTO;

public record QuizViewModel(string Title, string Description, EnumCategoriaQuiz Category);