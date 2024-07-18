namespace GeoLearn.Domain.Entities;

public class QuizOption : BaseEntity
{
    public int QuizQuestionId { get; private set; }
    public string OptionText { get; private set; }
    public bool IsCorrect { get; private set; }

    public QuizQuestion QuizQuestion { get; set; }
    
}