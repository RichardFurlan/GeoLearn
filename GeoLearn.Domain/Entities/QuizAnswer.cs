namespace GeoLearn.Domain.Entities;

public class QuizAnswer : BaseEntity
{
    public QuizAnswer(int userId, int quizId)
    {
        UserId = userId;
        QuizId = quizId;
        SubmissionDate = DateTime.Now;
        QuizOptionAnswers = new List<QuizOptionAnswer>();;
    }

    public int UserId { get; private set; }
    public int QuizId { get; private set; }
    public DateTime SubmissionDate { get; private set; }

    public User User { get; private set; }
    public Quiz Quiz { get; private set; }
    public List<QuizOptionAnswer> QuizOptionAnswers { get; private set; }

    public void AddOptionAnswer(QuizOptionAnswer optionAnswer)
    {
        QuizOptionAnswers.Add(optionAnswer);
    }
}