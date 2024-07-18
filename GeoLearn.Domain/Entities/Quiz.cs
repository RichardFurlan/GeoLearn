namespace GeoLearn.Domain.Entities;

public class Quiz : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }

    public List<QuizQuestion> Questions { get; private set; }
}