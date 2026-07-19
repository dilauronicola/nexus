using Nexus.Domain.Common;

namespace Nexus.Domain.Assets;

public sealed class PurchaseInfo : ValueObject
{
    private PurchaseInfo()
    {
        Supplier = string.Empty;
        InvoiceNumber = string.Empty;
    }

    public PurchaseInfo(
        string supplier,
        string invoiceNumber,
        DateOnly purchaseDate,
        decimal purchasePrice)
    {
        if (string.IsNullOrWhiteSpace(supplier))
            throw new DomainException("Supplier is required.");

        Supplier = supplier.Trim();
        InvoiceNumber = invoiceNumber.Trim();
        PurchaseDate = purchaseDate;
        PurchasePrice = purchasePrice;
    }

    public string Supplier { get; }

    public string InvoiceNumber { get; }

    public DateOnly PurchaseDate { get; }

    public decimal PurchasePrice { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Supplier;
        yield return InvoiceNumber;
        yield return PurchaseDate;
        yield return PurchasePrice;
    }
}