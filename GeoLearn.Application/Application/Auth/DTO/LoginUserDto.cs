namespace GeoLearn.Application.Application.DTO;

public record LoginUserDto
{
    public string Email { get; init; }
    public string Password { get; init; }
}