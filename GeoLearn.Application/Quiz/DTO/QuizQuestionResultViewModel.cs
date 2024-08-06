using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Quiz.DTO;

public record QuizQuestionResultViewModel(string QuestionText, EnumNivelDificuldade Difficulty, int ExperiencePoints, QuizOptionResultViewModel? SelectedOption);