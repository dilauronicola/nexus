using Nexus.Domain.Common;

namespace Nexus.Domain.Parties;

public sealed class Rack : Entity
{
    private Rack()
    {
    }

    public Rack(Guid roomId, string name)
    {
        RoomId = roomId;

        Rename(name);
    }

    /// <summary>
    /// Parent Room identifier.
    /// </summary>
    public Guid RoomId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Rack name cannot be empty.");

        Name = name.Trim();

        Touch();
    }
}