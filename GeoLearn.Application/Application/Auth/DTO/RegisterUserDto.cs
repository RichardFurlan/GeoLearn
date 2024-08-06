namespace GeoLearn.Application.Application.DTO;

public record RegisterUserDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string PasswordConfirm { get; init; }
};