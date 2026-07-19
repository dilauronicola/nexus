using System.Net.Mail;
using Nexus.Domain.Common;

namespace Nexus.Domain.Shared.ValueObjects.Identity;

public sealed class Email : ValueObject
{
    private Email()
    {
        Value = string.Empty;
    }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Email cannot be empty.");

        value = value.Trim().ToLowerInvariant();

        try
        {
            _ = new MailAddress(value);
        }
        catch
        {
            throw new DomainException("Invalid email.");
        }

        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;
}