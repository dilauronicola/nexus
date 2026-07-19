using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Identity;

public sealed class TaxCode : ValueObject
{
    private TaxCode()
    {
        Value = string.Empty;
    }

    public TaxCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Tax code cannot be empty.");

        Value = value.Trim().ToUpperInvariant();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(TaxCode code) => code.Value;
}