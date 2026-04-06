namespace Accepta.Api.Infrastructure.Auth;

public class FakeCurrentUserService : ICurrentUserService
{
    public Guid UserId => Guid.Parse("11111111-1111-1111-1111-111111111111");
}