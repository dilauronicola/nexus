using System.Text.RegularExpressions;
using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Network;

public sealed class MacAddress : ValueObject
{
    private static readonly Regex Regex =
        new(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$",
            RegexOptions.Compiled);

    private MacAddress()
    {
        Value = string.Empty;
    }

    public MacAddress(string value)
    {
        value = value.Trim();

        if (!Regex.IsMatch(value))
            throw new DomainException("Invalid MAC address.");

        Value = value.ToUpperInvariant();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}