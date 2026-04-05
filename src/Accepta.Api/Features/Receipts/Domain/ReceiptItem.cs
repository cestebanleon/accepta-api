using System.Text.Json.Serialization;

namespace Accepta.Api.Features.Receipts.Domain;

public class ReceiptItem
{
    public int Id { get; private set; }

    public int ReceiptId { get; private set; }
    [JsonIgnore]
    public Receipt Receipt { get; private set; } = null!;

    public string Name { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice => UnitPrice * Quantity;

    private ReceiptItem() { }

    public ReceiptItem(string name, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        if (unitPrice < 0)
            throw new ArgumentException("Unit price must be >= 0");

        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        Name = name;
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        Quantity = quantity;
    }

    public void UpdateUnitPrice(decimal unitPrice)
    {
        if (unitPrice < 0)
            throw new ArgumentException("Unit price must be >= 0");

        UnitPrice = unitPrice;
    }
}