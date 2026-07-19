using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class AssetCategory : Entity
{
    private AssetCategory()
    {
    }

    public AssetCategory(string name)
    {
        Rename(name);
    }

    public string Name { get; private set; } = string.Empty;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Category name is required.");

        Name = name.Trim();

        Touch();
    }
}