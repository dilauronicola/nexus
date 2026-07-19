using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Geography;

public sealed class Address : ValueObject
{
    private Address()
    {
        Street = string.Empty;
        City = string.Empty;
        PostalCode = string.Empty;
        Province = string.Empty;
        Country = null!;
    }

    public Address(
        string street,
        string city,
        string postalCode,
        string province,
        Country country)
    {
        Street = street.Trim();
        City = city.Trim();
        PostalCode = postalCode.Trim();
        Province = province.Trim();
        Country = country;
    }

    public string Street { get; }

    public string City { get; }

    public string PostalCode { get; }

    public string Province { get; }

    public Country Country { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return PostalCode;
        yield return Province;
        yield return Country;
    }

    public override string ToString()
        => $"{Street}, {PostalCode} {City}";
}