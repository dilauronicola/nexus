using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Assets;

namespace Nexus.Infrastructure.Configurations;

public sealed class NetworkInterfaceConfiguration : IEntityTypeConfiguration<NetworkInterface>
{
    public void Configure(EntityTypeBuilder<NetworkInterface> builder)
    {
        builder.ToTable("NetworkInterfaces");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(x => x.IpAddress, ip =>
        {
            ip.Property(x => x.Value)
              .HasColumnName("IpAddress")
              .HasMaxLength(45)
              .IsRequired();
        });

        builder.OwnsOne(x => x.MacAddress, mac =>
        {
            mac.Property(x => x.Value)
               .HasColumnName("MacAddress")
               .HasMaxLength(17)
               .IsRequired();
        });

        builder.HasOne<Asset>()
            .WithMany(x => x.NetworkInterfaces)
            .HasForeignKey("AssetId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}