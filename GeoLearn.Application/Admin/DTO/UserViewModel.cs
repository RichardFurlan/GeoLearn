using GeoLearn.Domain.Entities;
using GeoLearn.Domain.ValueObjects;

namespace GeoLearn.Application.Admin.DTO;

public record UserViewModel
{
    public UserViewModel(string firstName, string lastName, string email, string? biography, string? personImage, string? phone, Address? adress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Biography = biography;
        PersonImage = personImage;
        Phone = phone;
        Adress = adress;
    }

    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string? Biography { get; init; }
    public string? PersonImage { get; init; }
    public string? Phone { get; init; }
    public Address? Adress { get; init; }
};