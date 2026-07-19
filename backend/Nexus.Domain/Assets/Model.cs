using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class Model : ValueObject
{
    private Model()
    {
        Name = string.Empty;
    }

    public Model(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Model name is required.");

        Name = name.Trim();
    }

    public string Name { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }

    public override string ToString() => Name;
}