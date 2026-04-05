using Accepta.Api.Common.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accepta.Api.Common.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users")
            .HasKey(m => m.Id);

        builder.Property(m => m.Email)
            .HasColumnType("varchar")
            .HasMaxLength(128);

        builder.Property<DateTime>("CreatedAt")
            .HasValueGenerator<CreatedAtGenerator>();
    }
}