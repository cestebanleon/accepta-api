using Accepta.Api.Features.Receipts.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accepta.Api.Features.Receipts.Persistence;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("receipts")
            .HasKey(r => r.Id);

        builder.Property(r => r.Alias)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property(r => r.ImageUrl)
            .HasColumnType("text");

        builder.Property(r => r.Currency)
            .HasColumnType("varchar")
            .HasMaxLength(3);

        builder.Property(r => r.TaxAmount)
            .HasColumnType("decimal(10,2)");

        builder.Property(r => r.TotalAmount)
            .HasColumnType("decimal(10,2)");

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId);

        builder.HasOne(r => r.Merchant)
            .WithMany()
            .HasForeignKey(r => r.MerchantId);

        builder.HasMany(x => x.Items)
               .WithOne(x => x.Receipt)
               .HasForeignKey(x => x.ReceiptId);

        builder.HasMany(x => x.Taxes)
               .WithOne(x => x.Receipt)
               .HasForeignKey(x => x.ReceiptId);
    }
}