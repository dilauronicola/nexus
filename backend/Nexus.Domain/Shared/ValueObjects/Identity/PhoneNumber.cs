using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Identity;

public sealed class PhoneNumber : ValueObject
{
    private PhoneNumber()
    {
        Value = string.Empty;
    }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Phone number cannot be empty.");

        Value = value.Trim();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(PhoneNumber phone) => phone.Value;
}