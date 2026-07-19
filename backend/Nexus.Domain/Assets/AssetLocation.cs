using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class AssetLocation : ValueObject
{
    private AssetLocation()
    {
        Description = string.Empty;
    }

    public AssetLocation(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Location is required.");

        Description = description.Trim();
    }

    public string Description { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Description;
    }
}