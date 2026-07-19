using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.Specifications;

public static class Guard
{
    public static string AgainstNullOrWhiteSpace(string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{paramName} cannot be empty.");

        return value.Trim();
    }
}