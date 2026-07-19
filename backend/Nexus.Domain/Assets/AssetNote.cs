using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class AssetNote : Entity
{
    private AssetNote()
    {
    }

    public AssetNote(string text)
    {
        ChangeText(text);
    }

    public string Text { get; private set; } = string.Empty;

    public void ChangeText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new DomainException("Note cannot be empty.");

        Text = text.Trim();

        Touch();
    }
}