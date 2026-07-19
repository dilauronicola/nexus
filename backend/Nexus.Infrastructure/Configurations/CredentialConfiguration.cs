using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Assets;

namespace Nexus.Infrastructure.Configurations;

public sealed class CredentialConfiguration : IEntityTypeConfiguration<Credential>
{
    public void Configure(EntityTypeBuilder<Credential> builder)
    {
        builder.ToTable("AssetCredentials");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Username)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne<Asset>()
            .WithMany(x => x.Credentials)
            .HasForeignKey("AssetId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}