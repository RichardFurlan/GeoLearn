namespace GeoLearn.Application.Quiz.DTO;

public record SubmitAnswerDTO
{
    public int QuizId { get; init; }
    public int UserId { get; init; }
    public List<int> SelectedOptionIds { get; init; }
};