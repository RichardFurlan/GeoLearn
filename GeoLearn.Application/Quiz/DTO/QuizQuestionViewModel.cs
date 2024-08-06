using GeoLearn.Application.Admin.DTO;
using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Quiz.DTO;

public record QuizQuestionViewModel(string QuestionText, EnumNivelDificuldade Difficulty, int ExperiencePoints, List<QuizOptionViewModel> Options);