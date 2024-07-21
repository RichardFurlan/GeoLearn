namespace GeoLearn.Domain.Model;

public class QuestionResponse
{
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> IncorrectAnswers { get; set; }
}