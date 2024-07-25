namespace GeoLearn.Domain.Entities;

public class User : BaseEntity
{
    public User(string firstName, string lastName, string email, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Adress = new Address();
        PasswordHash = passwordHash;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string? Biography { get; private set; }
    public string? PersonImage { get; private set; }
    public string? Phone { get; private set; }
    public Address? Adress { get; set; }
    public string PasswordHash { get; private set; }
}