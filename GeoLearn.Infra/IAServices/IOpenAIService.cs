using GeoLearn.Domain.Model;

namespace GeoLearn.Infra.IAServices;

public interface IOpenAIService
{
    Task<QuestionResponse> GenerateText(string categoria, string conteudo, string nivelDificuldade);
}