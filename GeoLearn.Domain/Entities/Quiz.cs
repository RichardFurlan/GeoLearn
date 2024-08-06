using GeoLearn.Domain.Enums;

namespace GeoLearn.Domain.Entities;

public class Quiz : BaseEntity
{
    public Quiz(string title, string description, EnumCategoriaQuiz category)
    {
        Title = title;
        Description = description;
        Category = category;

        Questions = new List<QuizQuestion>();
        SetDateUpdate();
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public EnumCategoriaQuiz Category  { get; private set; }

    public List<QuizQuestion> Questions { get; private set; }
    
    public void AddQuestion(QuizQuestion question)
    {
        Questions.Add(question);
    }

    public void UpdateDetails(string title, string description, EnumCategoriaQuiz category)
    {
        Title = title;
        Description = description;
        Category = category;
        SetDateUpdate();
    }
}