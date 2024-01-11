using Application.Features.Transactions.Queries;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal sealed class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public TransactionRepository(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public void CreateAsync(Transaction transaction)
    {
        _dbcontext.Transactions.AddAsync(transaction);
    }

    public async Task<PagedList<TransactionResponse>> GetAllAsync(string? symbol, string? SortColumn, string? SortOrder, int Page, int PageSize, CancellationToken cancellationToken = default)
    {
        IQueryable<Transaction> transactionsQuery = _dbcontext.Transactions;

        if (!string.IsNullOrWhiteSpace(symbol))
        {
            transactionsQuery = transactionsQuery.Where(x => x.Symbol == symbol);
        }

        Expression<Func<Transaction, object>> keySelector = SortColumn?.ToLower() switch
        {
            "symbol" => transaction => transaction.Symbol,
            "bid" => transaction => transaction.Bid,
            _ => transaction => transaction.PurchaseDateAtUtcNow
        };

        if(SortOrder?.ToLower() == "desc")
        {
            transactionsQuery = transactionsQuery.OrderByDescending(keySelector);
        }
        else
        {
            transactionsQuery = transactionsQuery.OrderBy(keySelector);
        }

        var transactionResponseQuery =  transactionsQuery
            .Select(t => new TransactionResponse(
                t.Id,                 
                t.Symbol,
                t.ShortName,
                t.LongName,
                t.Bid,
                t.Ask,
                t.RegularMarketPrice,
                t.RegularMarketDayHigh,
                t.RegularMarketDayLow,
                t.RegularMarketChange,
                t.RegularMarketChangePercent,
                t.RegularMarketOpen,
                t.Quantity,
                t.PricePerShare,
                t.PurchaseDateAtUtcNow));

        var transactions = await PagedList<TransactionResponse>.CreateAsync(transactionResponseQuery, Page, PageSize);

        return transactions;
    }

    public Task<Transaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbcontext.Set<Transaction>().SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
