using GeoLearn.Domain.Entities;

namespace GeoLearn.Application.Application.Admin.DTO;

public record UpdateUserDTO
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Biography { get; init; }
    public string? PersonImage { get; init; }
    public string? Phone { get; init; }
    public string? CPF { get; init; }
    public Address? Adress { get; init; }
    public string? Password { get; init; }
    public string? ConfirmPassword { get; init; }
};