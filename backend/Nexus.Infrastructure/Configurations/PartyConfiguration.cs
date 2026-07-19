using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Parties;

namespace Nexus.Infrastructure.Configurations;

public sealed class PartyConfiguration : IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        builder.ToTable("Parties");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(256);
        });

        builder.OwnsOne(x => x.Phone, phone =>
        {
            phone.Property(p => p.Value)
                .HasColumnName("Phone")
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.VatNumber, vat =>
        {
            vat.Property(v => v.Value)
                .HasColumnName("VatNumber")
                .HasMaxLength(32);
        });

        builder.OwnsOne(x => x.TaxCode, tax =>
        {
            tax.Property(t => t.Value)
                .HasColumnName("TaxCode")
                .HasMaxLength(32);
        });

        builder.HasMany(x => x.Sites)
            .WithOne()
            .HasForeignKey(x => x.PartyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Sites)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Contacts)
            .WithOne()
            .HasForeignKey(x => x.PartyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Contacts)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => x.Name);
    }
}
