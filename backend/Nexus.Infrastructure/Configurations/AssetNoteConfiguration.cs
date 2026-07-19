using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Assets;

namespace Nexus.Infrastructure.Configurations;

public sealed class AssetNoteConfiguration : IEntityTypeConfiguration<AssetNote>
{
    public void Configure(EntityTypeBuilder<AssetNote> builder)
    {
        builder.ToTable("AssetNotes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
            .HasMaxLength(4000)
            .IsRequired();

        builder.HasOne<Asset>()
            .WithMany(x => x.Notes)
            .HasForeignKey("AssetId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}