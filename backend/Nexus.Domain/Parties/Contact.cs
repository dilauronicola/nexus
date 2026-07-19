using Nexus.Domain.Common;
using Nexus.Domain.Shared.ValueObjects.Identity;

namespace Nexus.Domain.Parties;

public sealed class Contact : Entity
{
    private Contact()
    {
    }

    public Contact(
        Guid partyId,
        string firstName,
        string lastName,
        Email email,
        PhoneNumber phone)
    {
        PartyId = partyId;

        Rename(firstName, lastName);

        Email = email;
        Phone = phone;
    }

    public Guid PartyId { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public Email Email { get; private set; } = null!;

    public PhoneNumber Phone { get; private set; } = null!;

    public string FullName => $"{FirstName} {LastName}";

    public void Rename(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");

        FirstName = firstName.Trim();
        LastName = lastName.Trim();

        Touch();
    }

    public void ChangeEmail(Email email)
    {
        ArgumentNullException.ThrowIfNull(email);

        Email = email;

        Touch();
    }

    public void ChangePhone(PhoneNumber phone)
    {
        ArgumentNullException.ThrowIfNull(phone);

        Phone = phone;

        Touch();
    }
}