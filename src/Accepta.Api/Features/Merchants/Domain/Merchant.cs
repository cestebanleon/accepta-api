using Accepta.Api.Common.Domain;

namespace Accepta.Api.Features.Merchants.Domain;

public class Merchant
{
    public int Id { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public string Name { get; private set; } = null!;
    public string? Address { get; private set; }
    public string? Country { get; private set; }

    private Merchant() { }

    public Merchant(Guid userId, string name, string? address = null, string? country = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        UserId = userId;
        Name = name;
        Address = address;
        Country = country;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        Name = name;
    }

    public void UpdateAddress(string? address)
    {
        Address = address;
    }

    public void UpdateCountry(string? country)
    {
        Country = country;
    }
}