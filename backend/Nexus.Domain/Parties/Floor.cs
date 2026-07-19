using Nexus.Domain.Common;

namespace Nexus.Domain.Parties;

public sealed class Floor : Entity
{
    private readonly List<Room> _rooms = new();

    private Floor()
    {
    }

    public Floor(Guid buildingId, string name)
    {
        BuildingId = buildingId;

        Rename(name);
    }

    /// <summary>
    /// Parent Building identifier.
    /// </summary>
    public Guid BuildingId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public IReadOnlyCollection<Room> Rooms => _rooms;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Floor name cannot be empty.");

        Name = name.Trim();

        Touch();
    }

    public void AddRoom(Room room)
    {
        ArgumentNullException.ThrowIfNull(room);

        if (_rooms.Any(x => x.Id == room.Id))
            return;

        _rooms.Add(room);

        Touch();
    }

    public void RemoveRoom(Guid roomId)
    {
        var room = _rooms.FirstOrDefault(x => x.Id == roomId);

        if (room is null)
            return;

        _rooms.Remove(room);

        Touch();
    }
}