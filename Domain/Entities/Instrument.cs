using Domain.DomainEvents;
using SharedKernel;

namespace Domain.Entities;

public sealed class Instrument : Entity
{
    private Instrument(
        Guid id, 
        string symbol, 
        string name, 
        string longName, 
        decimal bid, 
        decimal ask, 
        decimal currentPrice, 
        decimal changeValue, 
        decimal changePercentage,
        decimal regularMarketPrice, 
        decimal regularMarketChange, 
        decimal regularMarketChangePercent,
        ICollection<Transaction> transactions) : base(id) 
    {
        Symbol = symbol;
        Name = name;
        LongName = longName;
        Bid = bid;
        Ask = ask;
        CurrentPrice = currentPrice;
        ChangeValue = changeValue;
        ChangePercentage = changePercentage;
        RegularMarketPrice = regularMarketPrice; 
        RegularMarketChange = regularMarketChange;
        RegularMarketChangePercent = regularMarketChangePercent;
        Transactions = transactions;
    }


    public string Symbol { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string LongName { get; private set; } = string.Empty;
    public decimal Bid { get; private set; }
    public decimal Ask { get; private set; }
    public decimal CurrentPrice { get; private set; }
    public decimal ChangeValue { get; private set; }
    public decimal ChangePercentage { get; private set; }
    public decimal RegularMarketPrice { get; private set; }
    public decimal RegularMarketChange { get; private set; }
    public decimal RegularMarketChangePercent { get; private set; }

    // Relationship with Transactions
    public ICollection<Transaction> Transactions { get; set; }

    public static Instrument Create(string symbol,
        string name,
        string longName,
        decimal bid,
        decimal ask,
        decimal currentPrice,
        decimal changeValue,
        decimal changePercentage,
        decimal regularMarketPrice,
        decimal regularMarketChange,
        decimal regularMarketChangePercent,
        ICollection<Transaction> transactions)
    {
        var instrument = new Instrument(
            Guid.NewGuid(), 
            symbol, 
            name, 
            longName, 
            bid, 
            ask, 
            currentPrice, 
            changeValue, 
            changePercentage, 
            regularMarketPrice, 
            regularMarketChange, 
            regularMarketChangePercent, 
            transactions);

        instrument.Raise(new InstrumentCreatedDomainEvent(instrument.Id));

        return instrument;
    }
}
