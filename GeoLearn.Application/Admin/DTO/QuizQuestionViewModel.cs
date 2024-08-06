using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Enums;

namespace GeoLearn.Application.Admin.DTO;

public record QuizQuestionViewModel(string QuestionText, EnumNivelDificuldade Difficulty, int ExperiencePoints, List<QuizOptionViewModel> Options);