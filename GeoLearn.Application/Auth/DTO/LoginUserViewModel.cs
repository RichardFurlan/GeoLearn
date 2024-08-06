namespace GeoLearn.Application.Auth.DTO;

public record LoginUserViewModel
{
    public LoginUserViewModel(string email, string token)
    {
        Email = email;
        Token = token;
    }

    public string Email { get; init; }
    public string Token { get; init; }
}