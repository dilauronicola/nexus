using Microsoft.EntityFrameworkCore;
using Nexus.Domain.Assets;
using Nexus.Domain.Common;
using Nexus.Domain.Organizations;
using Nexus.Domain.Parties;
using Nexus.Infrastructure.Configurations;

namespace Nexus.Infrastructure.Persistence;

public sealed class NexusDbContext : DbContext
{
    public NexusDbContext(DbContextOptions<NexusDbContext> options)
        : base(options)
    {
    }

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<Party> Parties => Set<Party>();

    public DbSet<Site> Sites => Set<Site>();

    public DbSet<Building> Buildings => Set<Building>();

    public DbSet<Floor> Floors => Set<Floor>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Rack> Racks => Set<Rack>();

    public DbSet<Asset> Assets => Set<Asset>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Registrazione esplicita di AssetConfiguration
        modelBuilder.ApplyConfiguration(new AssetConfiguration());

        // Registra tutte le altre configurazioni
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NexusDbContext).Assembly);
    }

    public override int SaveChanges()
    {
        UpdateAuditInformation();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        UpdateAuditInformation();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditInformation()
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(e => e.CreatedAt).CurrentValue = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Property(e => e.UpdatedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(e => e.CreatedAt).IsModified = false;
                    break;
            }
        }
    }
}