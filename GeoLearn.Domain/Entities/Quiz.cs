namespace GeoLearn.Domain.Entities;

public class Quiz : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public EnumCategoriaQuiz Category  { get; private set; }

    public List<QuizQuestion> Questions { get; private set; }
    
    public void AddQuestion(QuizQuestion question)
    {
        Questions.Add(question);
    }
}