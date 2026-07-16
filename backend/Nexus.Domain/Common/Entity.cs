namespace Nexus.Domain.Common;

public abstract class Entity
{
    protected Entity()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; protected init; } = Guid.NewGuid();

    public DateTime CreatedAt { get; protected set; }

    public DateTime? UpdatedAt { get; protected set; }

    protected void MarkAsUpdated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}