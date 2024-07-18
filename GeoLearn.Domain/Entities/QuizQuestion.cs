namespace GeoLearn.Domain.Entities;

public class QuizQuestion : BaseEntity
{
    public int QuizId { get; private set; }
    public int QuestionText { get; private set; }
    public EnumQuestionType QuestionType { get; private set; }

    public Quiz Quiz { get; private set; }
    public List<QuizOption> Options { get; private set; }
}