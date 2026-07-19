using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class AssetDocument : Entity
{
    private AssetDocument()
    {
    }

    public AssetDocument(
        string name,
        string fileName,
        string path)
    {
        Rename(name);
        ChangeFile(fileName, path);
    }

    public string Name { get; private set; } = string.Empty;

    public string FileName { get; private set; } = string.Empty;

    public string Path { get; private set; } = string.Empty;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Document name is required.");

        Name = name.Trim();

        Touch();
    }

    public void ChangeFile(string fileName, string path)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new DomainException("File name is required.");

        if (string.IsNullOrWhiteSpace(path))
            throw new DomainException("Path is required.");

        FileName = fileName.Trim();
        Path = path.Trim();

        Touch();
    }
}