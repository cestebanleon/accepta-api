using Accepta.Api.Features.Merchants.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accepta.Api.Features.Merchants.Persistence;

public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
{
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable("merchants")
            .HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property(m => m.Address)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property(m => m.Country)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId);
    }
}