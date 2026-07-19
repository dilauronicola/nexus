using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class Credential : Entity
{
    private Credential()
    {
    }

    public Credential(
        CredentialType type,
        string username,
        string password)
    {
        Type = type;
        ChangeUsername(username);
        ChangePassword(password);
    }

    public CredentialType Type { get; private set; }

    public string Username { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public void ChangeUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new DomainException("Username is required.");

        Username = username.Trim();

        Touch();
    }

    public void ChangePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new DomainException("Password is required.");

        Password = password;

        Touch();
    }

    public void ChangeType(CredentialType type)
    {
        Type = type;

        Touch();
    }
}