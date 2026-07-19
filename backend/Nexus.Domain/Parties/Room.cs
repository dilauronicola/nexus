using Nexus.Domain.Common;

namespace Nexus.Domain.Parties;

public sealed class Room : Entity
{
    private readonly List<Rack> _racks = new();

    private Room()
    {
    }

    public Room(Guid floorId, string name)
    {
        FloorId = floorId;

        Rename(name);
    }

    /// <summary>
    /// Parent Floor identifier.
    /// </summary>
    public Guid FloorId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public IReadOnlyCollection<Rack> Racks => _racks;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Room name cannot be empty.");

        Name = name.Trim();

        Touch();
    }

    public void AddRack(Rack rack)
    {
        ArgumentNullException.ThrowIfNull(rack);

        if (_racks.Any(x => x.Id == rack.Id))
            return;

        _racks.Add(rack);

        Touch();
    }

    public void RemoveRack(Guid rackId)
    {
        var rack = _racks.FirstOrDefault(x => x.Id == rackId);

        if (rack is null)
            return;

        _racks.Remove(rack);

        Touch();
    }
}