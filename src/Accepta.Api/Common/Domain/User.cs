namespace Accepta.Api.Common.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = null!;

    private User() { }

    public User(Guid id, string email)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("UserId is required");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");

        Id = id;
        Email = email;
    }
}