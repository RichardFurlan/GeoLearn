namespace GeoLearn.Domain.Entities;

public class User : BaseEntity
{
    public string FirtName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Biography { get; private set; }
    public string PersonImage { get; private set; }
    public string Phone { get; private set; }
    public Adress Adress { get; set; }
    public string PasswordHash { get; private set; }
}