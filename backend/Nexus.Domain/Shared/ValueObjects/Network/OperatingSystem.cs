using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class OperatingSystem : ValueObject
{
    private OperatingSystem()
    {
        Name = string.Empty;
    }

    public OperatingSystem(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Operating system is required.");

        Name = name.Trim();
    }

    public string Name { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }

    public override string ToString() => Name;
}