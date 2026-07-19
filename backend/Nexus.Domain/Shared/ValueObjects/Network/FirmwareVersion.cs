using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class FirmwareVersion : ValueObject
{
    private FirmwareVersion()
    {
        Value = string.Empty;
    }

    public FirmwareVersion(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Firmware version is required.");

        Value = value.Trim();
    }

    public string Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}