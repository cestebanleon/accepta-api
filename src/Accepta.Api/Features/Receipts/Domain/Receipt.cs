using Accepta.Api.Common.Domain;
using Accepta.Api.Features.Merchants.Domain;

namespace Accepta.Api.Features.Receipts.Domain;

public class Receipt
{
    public int Id { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public int MerchantId { get; private set; }
    public Merchant Merchant { get; private set; } = null!;

    public DateTime PurchaseDate { get; private set; }

    public decimal TotalAmount { get; private set; }
    public decimal TaxAmount { get; private set; }

    public string Currency { get; private set; } = null!;
    public string? Alias { get; private set; }
    public string? ImageUrl { get; private set; }

    public ICollection<ReceiptItem> Items { get; private set; } = [];
    public ICollection<ReceiptTax> Taxes { get; private set; } = [];

    private Receipt() { }

    public Receipt(
        Guid userId,
        int merchantId,
        DateTime purchaseDate,
        decimal totalAmount,
        string currency,
        string? alias = null,
        string? imageUrl = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required");

        if (merchantId <= 0)
            throw new ArgumentException("Merchant is required");

        if (totalAmount < 0)
            throw new ArgumentException("Amount must be positive");

        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be ISO code");

        UserId = userId;
        MerchantId = merchantId;
        PurchaseDate = purchaseDate;
        TotalAmount = totalAmount;
        Currency = currency.ToUpperInvariant();
        Alias = alias;
        ImageUrl = imageUrl;
    }

    public void AddItem(string name, int quantity, decimal unitPrice)
    {
        var item = new ReceiptItem(name, quantity, unitPrice);
        Items.Add(item);
    }

    public void AddTax(string name, decimal amount)
    {
        var tax = new ReceiptTax(name, amount);
        Taxes.Add(tax);
    }

    public void UpdateAmount(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be positive");

        TotalAmount = amount;
    }

    public void UpdateMerchant(int merchantId)
    {
        if (merchantId <= 0)
            throw new ArgumentException("MerchantId is required");

        MerchantId = merchantId;
    }

    public void UpdateAlias(string? alias)
    {
        Alias = alias;
    }

    public void UpdateImageUrl(string? imageUrl)
    {
        ImageUrl = imageUrl;
    }
}