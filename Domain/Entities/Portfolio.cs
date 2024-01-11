using Domain.DomainEvents;
using SharedKernel;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Transactions;

namespace Domain.Entities;

public sealed class Portfolio : Entity
{
    public Dictionary<string, int> Holdings { get; private set; }
    public Dictionary<string, decimal> CurrentPrices { get; private set; }
    public decimal CurrentMarketValue { get; private set; }

    public Portfolio()
    {
        Holdings = new Dictionary<string, int>();
        CurrentPrices = new Dictionary<string, decimal>();
        CurrentMarketValue = 0;
    }

    public void AddTransaction(TransactionResponse transaction)
    {
        if (!Holdings.ContainsKey(transaction.symbol))
        {
            Holdings[transaction.symbol] = transaction.quantity;

        }
        else
        {
            Holdings[transaction.symbol] += transaction.quantity;

        }
        CurrentPrices[transaction.symbol] = transaction.pricePerShare;
    }


    public void AddCurrentMarketValue(decimal currentPrice)
    {
        CurrentMarketValue += currentPrice;
    }

    public decimal CalculateMarketValue()
    {
        return CurrentMarketValue;
    }

    public decimal CalculateCostBasis()
    {

        decimal totalCostBasis = 0;
        foreach (var holding in Holdings)
        {
            string symbol = holding.Key;
            int quantity = holding.Value;
            if (CurrentPrices.TryGetValue(symbol, out decimal currentPrice))
            {
                totalCostBasis += currentPrice * quantity;
            }
        }
        return totalCostBasis;
    }

    public decimal CalculateUnrealizedReturnRate()
    {
        decimal costBasis = CalculateCostBasis();
        decimal marketValue = CalculateMarketValue();

        if (costBasis == 0)
        {
            return 0; // To avoid division by zero
        }

        return ((marketValue - costBasis) / costBasis) * 100;
    }

    public decimal CalculateUnrealizedProfitLoss()
    {
        decimal costBasis = CalculateCostBasis();
        decimal marketValue = CalculateMarketValue();

        return marketValue - costBasis;
    }

}