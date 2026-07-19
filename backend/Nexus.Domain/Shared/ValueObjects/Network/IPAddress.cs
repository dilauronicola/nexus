using System.Net;
using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Network;

public sealed class IPAddress : ValueObject
{
    private IPAddress()
    {
        Value = string.Empty;
    }

    public IPAddress(string value)
    {
        if (!System.Net.IPAddress.TryParse(value, out _))
            throw new DomainException("Invalid IP address.");

        Value = value.Trim();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(IPAddress ip) => ip.Value;
}