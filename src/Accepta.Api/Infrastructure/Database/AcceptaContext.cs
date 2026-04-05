using Accepta.Api.Common.Domain;
using Accepta.Api.Features.Merchants.Domain;
using Accepta.Api.Features.Receipts.Domain;

using Microsoft.EntityFrameworkCore;

namespace Accepta.Api.Infrastructure.Database;

public class AcceptaContext : DbContext
{
    public AcceptaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<Merchant> Merchants => Set<Merchant>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("accepta");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcceptaContext).Assembly);
    }
}