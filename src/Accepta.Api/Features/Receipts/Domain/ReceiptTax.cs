using System.Text.Json.Serialization;

namespace Accepta.Api.Features.Receipts.Domain;

public class ReceiptTax
{
    public int Id { get; private set; }

    public int ReceiptId { get; private set; }
    [JsonIgnore]
    public Receipt Receipt { get; private set; } = null!;

    public string Name { get; private set; } = null!;
    public decimal Amount { get; private set; }

    private ReceiptTax() { }

    public ReceiptTax(string name, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (amount < 0)
            throw new ArgumentException("Amount must be >= 0");

        Name = name;
        Amount = amount;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        Name = name;
    }
}