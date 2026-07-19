using Nexus.Domain.Common;

namespace Nexus.Domain.Parties;

public sealed class Building : Entity
{
    private readonly List<Floor> _floors = new();

    private Building()
    {
    }

    public Building(Guid siteId, string name)
    {
        SiteId = siteId;

        Rename(name);
    }

    /// <summary>
    /// Parent Site identifier.
    /// </summary>
    public Guid SiteId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public IReadOnlyCollection<Floor> Floors => _floors;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Building name cannot be empty.");

        Name = name.Trim();

        Touch();
    }

    public void AddFloor(Floor floor)
    {
        ArgumentNullException.ThrowIfNull(floor);

        if (_floors.Any(x => x.Id == floor.Id))
            return;

        _floors.Add(floor);

        Touch();
    }

    public void RemoveFloor(Guid floorId)
    {
        var floor = _floors.FirstOrDefault(x => x.Id == floorId);

        if (floor is null)
            return;

        _floors.Remove(floor);

        Touch();
    }
}