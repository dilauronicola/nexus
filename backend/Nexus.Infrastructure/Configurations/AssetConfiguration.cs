using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Assets;

namespace Nexus.Infrastructure.Configurations;

public sealed class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("Assets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Manufacturer, manufacturer =>
        {
            manufacturer.Property(x => x.Name)
                .HasColumnName("Manufacturer")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Model, model =>
        {
            model.Property(x => x.Name)
                .HasColumnName("Model")
                .HasMaxLength(150)
                .IsRequired();
        });

        builder.OwnsOne(x => x.SerialNumber, serial =>
        {
            serial.Property(x => x.Value)
                .HasColumnName("SerialNumber")
                .HasMaxLength(100);
        });

        builder.OwnsOne(x => x.FirmwareVersion, firmware =>
        {
            firmware.Property(x => x.Value)
                .HasColumnName("FirmwareVersion")
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.OperatingSystem, os =>
        {
            os.Property(x => x.Name)
                .HasColumnName("OperatingSystem")
                .HasMaxLength(100);
        });

        builder.OwnsOne(x => x.Warranty, warranty =>
        {
            warranty.Property(x => x.StartDate)
                .HasColumnName("WarrantyStart");

            warranty.Property(x => x.EndDate)
                .HasColumnName("WarrantyEnd");
        });

        builder.OwnsOne(x => x.PurchaseInfo, purchase =>
        {
            purchase.Property(x => x.Supplier)
                .HasMaxLength(200);

            purchase.Property(x => x.InvoiceNumber)
                .HasMaxLength(100);

            purchase.Property(x => x.PurchaseDate);

            purchase.Property(x => x.PurchasePrice)
                .HasPrecision(18, 2);
        });

        builder.OwnsOne(x => x.Location, location =>
        {
            location.Property(x => x.Description)
                .HasColumnName("Location")
                .HasMaxLength(200);
        });

        builder.HasOne(x => x.Category)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.NetworkInterfaces)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.NetworkInterfaces)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Credentials)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Credentials)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Documents)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Documents)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Notes)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Notes)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.Type);
        builder.HasIndex(x => x.Status);
    }
}