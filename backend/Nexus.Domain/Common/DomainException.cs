namespace Nexus.Domain.Common;

/// <summary>
/// Represents a business rule violation inside the domain.
/// </summary>
public sealed class DomainException : Exception
{
    public DomainException(string message)
        : base(message)
    {
    }
}