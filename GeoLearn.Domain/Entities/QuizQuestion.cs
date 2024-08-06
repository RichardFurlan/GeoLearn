using GeoLearn.Domain.Enums;

namespace GeoLearn.Domain.Entities;

public class QuizQuestion : BaseEntity
{
    public QuizQuestion(string questionText, EnumNivelDificuldade difficulty, int experiencePoints)
    {
        QuestionText = questionText;
        Difficulty = difficulty;
        ExperiencePoints = experiencePoints;
    }

    public int QuizId { get; private set; }
    public string QuestionText { get; private set; }
    public EnumNivelDificuldade Difficulty  { get; private set; }
    public int ExperiencePoints { get; private set; }

    public Quiz Quiz { get; private set; }
    public List<QuizOption> Options { get; private set; }

    public void AddOption(QuizOption option)
    {
        Options.Add(option);
    }
}