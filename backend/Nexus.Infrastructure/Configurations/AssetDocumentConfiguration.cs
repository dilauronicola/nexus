using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Assets;

namespace Nexus.Infrastructure.Configurations;

public sealed class AssetDocumentConfiguration : IEntityTypeConfiguration<AssetDocument>
{
    public void Configure(EntityTypeBuilder<AssetDocument> builder)
    {
        builder.ToTable("AssetDocuments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Path)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne<Asset>()
            .WithMany(x => x.Documents)
            .HasForeignKey("AssetId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}