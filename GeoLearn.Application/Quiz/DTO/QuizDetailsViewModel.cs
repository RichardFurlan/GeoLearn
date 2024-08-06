using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Quiz.DTO;

public record QuizDetailsViewModel(string Title, string Description, EnumCategoriaQuiz Category, List<QuizQuestionViewModel> Questions);