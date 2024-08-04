using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record QuizQuestionViewModel(string QuestionText, EnumNivelDificuldade Difficulty, int ExperiencePoints, List<QuizOptionViewModel> Options);