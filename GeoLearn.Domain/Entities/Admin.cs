namespace GeoLearn.Domain.Entities;

public class Admin : BaseEntity
{
    public string FirtsName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
}