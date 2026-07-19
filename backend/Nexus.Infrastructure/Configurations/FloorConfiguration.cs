using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Parties;

namespace Nexus.Infrastructure.Configurations;

public sealed class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.ToTable("Floors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.BuildingId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.HasMany(x => x.Rooms)
            .WithOne()
            .HasForeignKey(x => x.FloorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Rooms)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => x.BuildingId);

        builder.HasIndex(x => new
        {
            x.BuildingId,
            x.Name
        });
    }
}