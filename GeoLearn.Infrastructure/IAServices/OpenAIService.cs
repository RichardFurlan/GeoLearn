using System.Net.Http.Json;
using GeoLearn.Domain.Entities;
using GeoLearn.Domain.Model;
using Microsoft.Extensions.Options;

namespace GeoLearn.Infrastructure.IAServices;

public class OpenAIService : IOpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    
    public OpenAIService(HttpClient httpClient, IOptions<OpenAIOptions> options)
    {
        _httpClient = httpClient;
        _apiKey = options.Value.ApiKey;
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public async Task<QuestionResponse> GenerateText(string categoria, string conteudo, string nivelDificuldade)
    {
        var prompt = $"Gere uma pergunta de múltipla escolha sobre {categoria} com o seguinte conteudo: {conteudo}, e com o seguinte nivel de Dificuldade: {nivelDificuldade}. Inclua a pergunta, a resposta correta e quatro respostas incorretas.";
        var request = new
        {
            model = "text-davinci-003",
            prompt = prompt,
            max_tokens = 180
        };
        
        var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/completions", request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API request failed with status code {response.StatusCode}");
        }

        var responseData = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        var text = responseData?.Choices?.FirstOrDefault()?.Text ?? string.Empty;
        
        var questionResponse = new QuestionResponse
        {
            Question = ExtractQuestion(text),
            CorrectAnswer = ExtractCorrectAnswer(text),
            IncorrectAnswers = ExtractIncorrectAnswers(text)
        };

        return questionResponse;
        
    }

    private string ExtractQuestion(string responseText)
    {
        var lines = responseText.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        return lines.FirstOrDefault();
    }

    private string ExtractCorrectAnswer(string responseText)
    {
        var lines = responseText.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        return lines.Skip(1).FirstOrDefault();
    }

    private List<string> ExtractIncorrectAnswers(string responseText)
    {
        var lines = responseText.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        return lines.Skip(2).Take(4).ToList();
    }
    
}