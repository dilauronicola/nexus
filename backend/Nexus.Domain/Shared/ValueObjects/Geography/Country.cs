using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Geography;

public sealed class Country : ValueObject
{
    private Country()
    {
        Code = string.Empty;
        Name = string.Empty;
    }

    public Country(string code, string name)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Country code is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Country name is required.");

        Code = code.Trim().ToUpperInvariant();
        Name = name.Trim();
    }

    public string Code { get; }

    public string Name { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Code;
    }

    public override string ToString() => Name;
}