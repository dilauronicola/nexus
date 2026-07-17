namespace Nexus.Domain.Common;

/// <summary>
/// Base class for all domain entities.
/// </summary>
public abstract class Entity
{
    protected Entity()
    {
    }

    /// <summary>
    /// Unique identifier of the entity.
    /// </summary>
    public Guid Id { get; protected init; } = Guid.NewGuid();

    /// <summary>
    /// UTC date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// UTC date and time of the last modification.
    /// </summary>
    public DateTime? UpdatedAt { get; protected set; }

    /// <summary>
    /// Updates the modification timestamp.
    /// </summary>
    protected void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}