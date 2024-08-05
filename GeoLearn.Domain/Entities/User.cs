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
    public string? Cpf { get; private set; }
    public Address? Adress { get; set; }
    public string PasswordHash { get; private set; }
    
    public void UpdateDetails(string? firstName, string? lastName, string? email, string? biography, string? personImage, string? phone, string? cpf, Address? address)
    {
        if (!string.IsNullOrEmpty(firstName)) FirstName = firstName;
        if (!string.IsNullOrEmpty(lastName)) LastName = lastName;
        if (!string.IsNullOrEmpty(email)) Email = email;
        if (!string.IsNullOrEmpty(biography)) Biography = biography;
        if (!string.IsNullOrEmpty(personImage)) PersonImage = personImage;
        if (!string.IsNullOrEmpty(phone)) Phone = phone;
        if (!string.IsNullOrEmpty(cpf)) Cpf = cpf;
        if (address != null) Adress = address;
        SetDateUpdate();
    }
    
}