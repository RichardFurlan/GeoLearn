namespace GeoLearn.Domain.Entities;

public record Adress(
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode);