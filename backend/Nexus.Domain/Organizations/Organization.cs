using Nexus.Domain.Common;

namespace Nexus.Domain.Organizations;

public sealed class Organization : AggregateRoot
{
    private Organization()
    {
        Name = string.Empty;
    }

    public Organization(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Organization name cannot be empty.", nameof(name));

        Name = name.Trim();
        IsActive = true;
    }

    public string Name { get; private set; }

    public bool IsActive { get; private set; }

   public void Activate()
    {
        if (!IsActive)
        {
            IsActive = true;
            MarkAsUpdated();
        }
    }

    public void Deactivate()
    {
        if (IsActive)
        {
            IsActive = false;
            MarkAsUpdated();
        }
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(
                "Organization name cannot be empty.",
                nameof(newName));

        Name = newName.Trim();

        MarkAsUpdated();
    }
}