using Accepta.Api.Common.Domain;
using Accepta.Api.Features.Merchants.Domain;
using Accepta.Api.Features.Receipts.Domain;
using Accepta.Api.Infrastructure.Auth;

using Microsoft.EntityFrameworkCore;

namespace Accepta.Api.Infrastructure.Database;

public class AcceptaContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public AcceptaContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<Merchant> Merchants => Set<Merchant>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("accepta");

        modelBuilder.Entity<Receipt>()
            .HasQueryFilter(u => u.UserId == _currentUserService.UserId);

        modelBuilder.Entity<Merchant>()
            .HasQueryFilter(u => u.UserId == _currentUserService.UserId);

        modelBuilder.Entity<User>()
            .HasQueryFilter(u => u.Id == _currentUserService.UserId);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcceptaContext).Assembly);
    }
}