namespace GeoLearn.Application.Auth.DTO;

public record LoginUserDTO
{
    public string Email { get; init; }
    public string Password { get; init; }
}