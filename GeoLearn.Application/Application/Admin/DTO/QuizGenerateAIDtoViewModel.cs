namespace GeoLearn.Application.Application.Admin.DTO;

public record QuizGenerateAIDtoViewModel
{
    public QuizGenerateAIDtoViewModel(string question, string correctAnswer ,List<string> incorrectAnswers)
    {
        Question = question;
        CorrectAnswer = correctAnswer;
        IncorrectAnswers = incorrectAnswers;
    }

    public string Question { get; init; }
    public string CorrectAnswer { get; init; }
    public List<string> IncorrectAnswers { get; init; }
};