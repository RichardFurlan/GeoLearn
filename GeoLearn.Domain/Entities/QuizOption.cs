namespace GeoLearn.Domain.Entities;

public class QuizOption : BaseEntity
{
    public QuizOption(int quizQuestionId, string optionText, bool isCorrect)
    {
        QuizQuestionId = quizQuestionId;
        OptionText = optionText;
        IsCorrect = isCorrect;
    }

    public int QuizQuestionId { get; private set; }
    public string OptionText { get; private set; }
    public bool IsCorrect { get; private set; }

    public QuizQuestion QuizQuestion { get; private set; }
    public ICollection<QuizOptionAnswer> QuizOptionAnswers { get; private set; }
    
}