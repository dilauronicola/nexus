using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class Manufacturer : ValueObject
{
    private Manufacturer()
    {
        Name = string.Empty;
    }

    public Manufacturer(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Manufacturer name is required.");

        Name = name.Trim();
    }

    public string Name { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }

    public override string ToString() => Name;
}