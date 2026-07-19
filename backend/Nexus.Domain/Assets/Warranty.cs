using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class Warranty : ValueObject
{
    private Warranty()
    {
    }

    public Warranty(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
            throw new DomainException("Warranty end date cannot be before start date.");

        StartDate = startDate;
        EndDate = endDate;
    }

    public DateOnly StartDate { get; }

    public DateOnly EndDate { get; }

    public bool IsExpired => EndDate < DateOnly.FromDateTime(DateTime.UtcNow);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}