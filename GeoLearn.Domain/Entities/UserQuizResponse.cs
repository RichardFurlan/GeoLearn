namespace GeoLearn.Domain.Entities;

public class UserQuizResponse : BaseEntity
{
    public int UserId { get; private set; }
    public int QuizQuestionId { get; private set; }
    public int? QuizOptionId { get; private set; }
    public string AnswerText { get; private set; }

    public User User { get; private set; }
    public QuizQuestion QuizQuestion { get; private set; }
    public QuizOption QuizOption { get; private set; }  
}