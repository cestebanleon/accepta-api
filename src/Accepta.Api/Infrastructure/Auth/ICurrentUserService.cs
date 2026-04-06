namespace Accepta.Api.Infrastructure.Auth;

public interface ICurrentUserService
{
    Guid UserId { get; }
}