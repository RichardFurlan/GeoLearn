using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Model;

namespace GeoLearn.Infrastructure.IAServices;

public interface IOpenAIService
{
    Task<QuestionResponse> GenerateText(string categoria, string conteudo, string nivelDificuldade);
}