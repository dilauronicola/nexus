using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Identity;

public sealed class VatNumber : ValueObject
{
    private VatNumber()
    {
        Value = string.Empty;
    }

    public VatNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("VAT number cannot be empty.");

        Value = value.Trim().ToUpperInvariant();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(VatNumber vat) => vat.Value;
}