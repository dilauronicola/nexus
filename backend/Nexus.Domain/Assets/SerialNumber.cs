using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class SerialNumber : ValueObject
{
    private SerialNumber()
    {
        Value = string.Empty;
    }

    public SerialNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Serial number is required.");

        Value = value.Trim().ToUpperInvariant();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}