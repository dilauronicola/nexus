using Nexus.Domain.Common;
using Nexus.Domain.Shared.ValueObjects.Network;

namespace Nexus.Domain.Assets;

public sealed class NetworkInterface : Entity
{
    private NetworkInterface()
    {
    }

    public NetworkInterface(
        string name,
        IPAddress ipAddress,
        MacAddress macAddress)
    {
        Name = name;
        IpAddress = ipAddress;
        MacAddress = macAddress;
    }

    public string Name { get; private set; } = string.Empty;

    public IPAddress IpAddress { get; private set; } = null!;

    public MacAddress MacAddress { get; private set; } = null!;

    public void ChangeIp(IPAddress ip)
    {
        IpAddress = ip;
        Touch();
    }

    public void ChangeMac(MacAddress mac)
    {
        MacAddress = mac;
        Touch();
    }
}