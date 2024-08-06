namespace GeoLearn.Domain.Entities;

public class QuizOptionAnswer : BaseEntity
{
    public QuizOptionAnswer(int quizAnswerId, int quizOptionId)
    {
        QuizAnswerId = quizAnswerId;
        QuizOptionId = quizOptionId;
    }

    public int QuizAnswerId { get; private set; }
    public int QuizOptionId { get; private set; }

    public QuizAnswer QuizAnswer { get; private set; }
    public QuizOption QuizOption { get; private set; }
}