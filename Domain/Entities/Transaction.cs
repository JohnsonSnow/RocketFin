using Domain.DomainEvents;
using SharedKernel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Domain.Entities;

public sealed class Transaction : Entity
{
    private Transaction(Guid id, string symbol, string shortName, string longName, decimal bid, decimal ask, decimal regularMarketPrice, decimal regularMarketDayHigh, decimal regularMarketDayLow, decimal regularMarketChange, decimal regularMarketChangePercent, decimal regularMarketOpen, int quantity, decimal pricePerShare, DateTime purchaseDateAtUtcNow) : base(id)
    {
        Symbol = symbol;
        ShortName = shortName;
        LongName = longName;
        Bid = bid;
        Ask = ask;
        RegularMarketPrice = regularMarketPrice;
        Quantity = quantity;
        PricePerShare = pricePerShare;
        PurchaseDateAtUtcNow = purchaseDateAtUtcNow;
        RegularMarketChange = regularMarketChange;
        RegularMarketOpen = regularMarketOpen;
        RegularMarketChangePercent = regularMarketChangePercent;
        RegularMarketDayHigh = regularMarketDayHigh;
        RegularMarketDayLow = regularMarketDayLow;

    }
  
    public string Symbol { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }
    public decimal Bid { get; set; }
    public decimal Ask { get; set; }
    public decimal RegularMarketPrice { get; set; }
    public decimal RegularMarketDayHigh { get; set; }
    public decimal RegularMarketDayLow { get; set; }
    public decimal RegularMarketChange { get; set; }
    public decimal RegularMarketChangePercent { get; set; }
    public decimal RegularMarketOpen { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerShare { get; set; }
    public DateTime PurchaseDateAtUtcNow { get; set; }

    public decimal TotalCost() { 
        return Quantity * PricePerShare; 
    }

    public static Transaction Create(string symbol, string shortName, string longName, decimal bid, decimal ask, decimal regularMarketPrice, decimal regularMarketDayHigh, decimal regularMarketDayLow, decimal regularMarketChange, decimal regularMarketChangePercent, decimal regularMarketOpen, int quantity, decimal pricePerShare, DateTime purchaseDateAtUtcNow)
    {
        var transaction = new Transaction(Guid.NewGuid(), symbol, shortName, longName, bid, ask, regularMarketPrice, regularMarketDayHigh, regularMarketDayLow, regularMarketChange, regularMarketChangePercent, regularMarketOpen, quantity, pricePerShare, purchaseDateAtUtcNow);
        transaction.Raise(new TransactionCreatedDomainEvent(transaction.Id));

        return transaction;
    }
}
