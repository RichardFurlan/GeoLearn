namespace GeoLearn.Application.Admin.DTO;

public record CreateUserDTO
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string PasswordConfirm { get; init; }
};