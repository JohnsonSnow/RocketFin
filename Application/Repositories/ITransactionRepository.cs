using Application.Features.Transactions.Queries;
using Domain.Entities;
using SharedKernel;

namespace Application.Repositories;

public interface ITransactionRepository
{
    void CreateAsync(Transaction transaction);
    Task<PagedList<TransactionResponse>> GetAllAsync(string? symbol, string? SortColumn, string? SortOrder, int Page = 1, int PageSize = 50,  CancellationToken cancellationToken = default);
    Task<Transaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

}
