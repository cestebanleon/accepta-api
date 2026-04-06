using Accepta.Api.Infrastructure.Auth;
using Accepta.Api.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

namespace Accepta.Api.Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, FakeCurrentUserService>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectrionString)
    {
        services.AddDbContext<AcceptaContext>(options =>
                options.UseNpgsql(connectrionString,
                    npgsqlOptions =>
                    {
                        npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "accepta");
                    })
            .UseSnakeCaseNamingConvention());

        return services;
    }
}