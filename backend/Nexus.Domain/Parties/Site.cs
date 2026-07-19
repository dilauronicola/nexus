using Nexus.Domain.Common;
using Nexus.Domain.Shared.ValueObjects.Geography;

namespace Nexus.Domain.Parties;

public sealed class Site : Entity
{
    private readonly List<Building> _buildings = new();

    private Site()
    {
    }

    public Site(Guid partyId, string name, Address address)
    {
        PartyId = partyId;

        Rename(name);

        Address = address;

        IsActive = true;
    }

    /// <summary>
    /// Foreign key of the owning Party.
    /// </summary>
    public Guid PartyId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public Address Address { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public IReadOnlyCollection<Building> Buildings => _buildings;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Site name cannot be empty.");

        Name = name.Trim();

        Touch();
    }

    public void ChangeAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address);

        Address = address;

        Touch();
    }

    public void AddBuilding(Building building)
    {
        ArgumentNullException.ThrowIfNull(building);

        if (_buildings.Any(x => x.Id == building.Id))
            return;

        _buildings.Add(building);

        Touch();
    }

    public void RemoveBuilding(Guid buildingId)
    {
        var building = _buildings.FirstOrDefault(x => x.Id == buildingId);

        if (building is null)
            return;

        _buildings.Remove(building);

        Touch();
    }

    public void Activate()
    {
        if (IsActive)
            return;

        IsActive = true;

        Touch();
    }

    public void Deactivate()
    {
        if (!IsActive)
            return;

        IsActive = false;

        Touch();
    }
}