using Accepta.Api.Features.Receipts.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accepta.Api.Features.Receipts.Persistence;

public class ReceiptTaxConfiguration : IEntityTypeConfiguration<ReceiptTax>
{
    public void Configure(EntityTypeBuilder<ReceiptTax> builder)
    {
        builder.ToTable("receipt_taxes")
            .HasKey(rt => rt.Id);

        builder.Property(rt => rt.Name)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property(rt => rt.Amount)
            .HasColumnType("decimal(10,2)");
    }
}