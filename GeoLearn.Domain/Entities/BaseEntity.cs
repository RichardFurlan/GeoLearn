namespace GeoLearn.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        Inactive = false;
        CreatedAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }

    public int Id { get; private set; }
    public bool Inactive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
}