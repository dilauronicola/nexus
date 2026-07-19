using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class Asset : AggregateRoot
{
    private readonly List<NetworkInterface> _networkInterfaces = new();
    private readonly List<Credential> _credentials = new();
    private readonly List<AssetDocument> _documents = new();
    private readonly List<AssetNote> _notes = new();

    private Asset()
    {
    }

    public Asset(
        string name,
        AssetType type,
        Manufacturer manufacturer,
        Model model)
    {
        Rename(name);

        Type = type;
        Manufacturer = manufacturer;
        Model = model;

        Status = AssetStatus.InStock;
    }

    public string Name { get; private set; } = string.Empty;

    public AssetType Type { get; private set; }

    public AssetStatus Status { get; private set; }

    public Manufacturer Manufacturer { get; private set; } = null!;

    public Model Model { get; private set; } = null!;

    public SerialNumber? SerialNumber { get; private set; }

    public FirmwareVersion? FirmwareVersion { get; private set; }

    public OperatingSystem? OperatingSystem { get; private set; }

    public Warranty? Warranty { get; private set; }

    public PurchaseInfo? PurchaseInfo { get; private set; }

    public AssetCategory? Category { get; private set; }

    public AssetLocation? Location { get; private set; }

    public IReadOnlyCollection<NetworkInterface> NetworkInterfaces => _networkInterfaces;

    public IReadOnlyCollection<Credential> Credentials => _credentials;

    public IReadOnlyCollection<AssetDocument> Documents => _documents;

    public IReadOnlyCollection<AssetNote> Notes => _notes;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Asset name cannot be empty.");

        Name = name.Trim();

        Touch();
    }

    public void ChangeSerialNumber(SerialNumber serialNumber)
    {
        ArgumentNullException.ThrowIfNull(serialNumber);

        SerialNumber = serialNumber;

        Touch();
    }

    public void ChangeFirmwareVersion(FirmwareVersion firmwareVersion)
    {
        ArgumentNullException.ThrowIfNull(firmwareVersion);

        FirmwareVersion = firmwareVersion;

        Touch();
    }

    public void ChangeOperatingSystem(OperatingSystem operatingSystem)
    {
        ArgumentNullException.ThrowIfNull(operatingSystem);

        OperatingSystem = operatingSystem;

        Touch();
    }

    public void ChangeWarranty(Warranty warranty)
    {
        ArgumentNullException.ThrowIfNull(warranty);

        Warranty = warranty;

        Touch();
    }

    public void ChangePurchaseInfo(PurchaseInfo purchaseInfo)
    {
        ArgumentNullException.ThrowIfNull(purchaseInfo);

        PurchaseInfo = purchaseInfo;

        Touch();
    }

    public void ChangeCategory(AssetCategory category)
    {
        ArgumentNullException.ThrowIfNull(category);

        Category = category;

        Touch();
    }

    public void ChangeLocation(AssetLocation location)
    {
        ArgumentNullException.ThrowIfNull(location);

        Location = location;

        Touch();
    }

    public void ChangeStatus(AssetStatus status)
    {
        Status = status;

        Touch();
    }

    public void AddNetworkInterface(NetworkInterface networkInterface)
    {
        ArgumentNullException.ThrowIfNull(networkInterface);

        if (_networkInterfaces.Any(x => x.Id == networkInterface.Id))
            return;

        _networkInterfaces.Add(networkInterface);

        Touch();
    }

    public void RemoveNetworkInterface(Guid id)
    {
        var item = _networkInterfaces.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return;

        _networkInterfaces.Remove(item);

        Touch();
    }

    public void AddCredential(Credential credential)
    {
        ArgumentNullException.ThrowIfNull(credential);

        if (_credentials.Any(x => x.Id == credential.Id))
            return;

        _credentials.Add(credential);

        Touch();
    }

    public void RemoveCredential(Guid id)
    {
        var item = _credentials.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return;

        _credentials.Remove(item);

        Touch();
    }

    public void AddDocument(AssetDocument document)
    {
        ArgumentNullException.ThrowIfNull(document);

        if (_documents.Any(x => x.Id == document.Id))
            return;

        _documents.Add(document);

        Touch();
    }

    public void RemoveDocument(Guid id)
    {
        var item = _documents.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return;

        _documents.Remove(item);

        Touch();
    }

    public void AddNote(AssetNote note)
    {
        ArgumentNullException.ThrowIfNull(note);

        if (_notes.Any(x => x.Id == note.Id))
            return;

        _notes.Add(note);

        Touch();
    }

    public void RemoveNote(Guid id)
    {
        var item = _notes.FirstOrDefault(x => x.Id == id);

        if (item is null)
            return;

        _notes.Remove(item);

        Touch();
    }
}