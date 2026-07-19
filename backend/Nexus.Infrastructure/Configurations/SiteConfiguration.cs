using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Parties;

namespace Nexus.Infrastructure.Configurations;

public sealed class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.ToTable("Sites");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.PartyId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(x => x.Street)
                .HasColumnName("Street")
                .HasMaxLength(200)
                .IsRequired();

            address.Property(x => x.City)
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsRequired();

            address.Property(x => x.PostalCode)
                .HasColumnName("PostalCode")
                .HasMaxLength(20)
                .IsRequired();

            address.Property(x => x.Province)
                .HasColumnName("Province")
                .HasMaxLength(100)
                .IsRequired();

            address.OwnsOne(x => x.Country, country =>
            {
                country.Property(c => c.Code)
                    .HasColumnName("CountryCode")
                    .HasMaxLength(2)
                    .IsRequired();

                country.Property(c => c.Name)
                    .HasColumnName("CountryName")
                    .HasMaxLength(100)
                    .IsRequired();
            });
        });

        builder.HasMany(x => x.Buildings)
            .WithOne()
            .HasForeignKey(x => x.SiteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Buildings)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => x.PartyId);

        builder.HasIndex(x => new
        {
            x.PartyId,
            x.Name
        });
    }
}