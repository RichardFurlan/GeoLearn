namespace GeoLearn.Application.Application.DTO;

public record RegisterUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
};