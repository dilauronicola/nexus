using Nexus.Domain.Common;
using Nexus.Domain.Shared.ValueObjects.Geography;
using Nexus.Domain.Shared.ValueObjects.Identity;

namespace Nexus.Domain.Parties;

public sealed class Party : AggregateRoot
{
    private readonly List<Contact> _contacts = new();
    private readonly List<Site> _sites = new();

    private Party()
    {
    }

    public Party(string name, PartyType type)
    {
        Rename(name);

        Type = type;
        IsActive = true;
    }

    public string Name { get; private set; } = string.Empty;

    public PartyType Type { get; private set; }

    public Email? Email { get; private set; }

    public PhoneNumber? Phone { get; private set; }

    public VatNumber? VatNumber { get; private set; }

    public TaxCode? TaxCode { get; private set; }

    public bool IsActive { get; private set; }

    public IReadOnlyCollection<Contact> Contacts => _contacts;

    public IReadOnlyCollection<Site> Sites => _sites;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Party name cannot be empty.");

        Name = name.Trim();

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

    public void ChangeVatNumber(VatNumber vatNumber)
    {
        ArgumentNullException.ThrowIfNull(vatNumber);

        VatNumber = vatNumber;

        Touch();
    }

    public void ChangeTaxCode(TaxCode taxCode)
    {
        ArgumentNullException.ThrowIfNull(taxCode);

        TaxCode = taxCode;

        Touch();
    }

    public Contact AddContact(
        string firstName,
        string lastName,
        Email email,
        PhoneNumber phone)
    {
        var contact = new Contact(
            Id,
            firstName,
            lastName,
            email,
            phone);

        _contacts.Add(contact);

        Touch();

        return contact;
    }

    public void RemoveContact(Guid contactId)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == contactId);

        if (contact is null)
            return;

        _contacts.Remove(contact);

        Touch();
    }

    public Site AddSite(
        string name,
        Address address)
    {
        var site = new Site(Id, name, address);

        _sites.Add(site);

        Touch();

        return site;
    }

    public void RemoveSite(Guid siteId)
    {
        var site = _sites.FirstOrDefault(s => s.Id == siteId);

        if (site is null)
            return;

        _sites.Remove(site);

        Touch();
    }

    public void Activate()
    {
        if (IsActive)
            return;

        IsActive = true;

        Touch();
    }

    public void Deactivate()
    {
        if (!IsActive)
            return;

        IsActive = false;

        Touch();
    }
}