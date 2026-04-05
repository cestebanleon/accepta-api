using Accepta.Api.Features.Receipts.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accepta.Api.Features.Receipts.Persistence;

public class ReceiptItemConfiguration : IEntityTypeConfiguration<ReceiptItem>
{
    public void Configure(EntityTypeBuilder<ReceiptItem> builder)
    {
        builder.ToTable("receipt_items")
            .HasKey(ri => ri.Id);

        builder.Property(r => r.Name)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property(ri => ri.UnitPrice)
            .HasColumnType("decimal(10,2)");
    }
}