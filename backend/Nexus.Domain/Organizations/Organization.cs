using Nexus.Domain.Common;

namespace Nexus.Domain.Organizations;

public sealed class Organization : AggregateRoot
{
    private Organization()
    {
    }

    public Organization(string name)
    {
        Rename(name);
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new DomainException("Organization name cannot be empty.");

        Name = newName.Trim();
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