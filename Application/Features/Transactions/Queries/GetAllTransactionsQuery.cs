using Application.Messaging;
using SharedKernel;

namespace Application.Features.Transactions.Queries;

public sealed record GetAllTransactionsQuery(string? symbol, string? SortColumn, string? SortOrder, int Page = 1, int PageSize= 20) : IQuery<PagedList<TransactionResponse>>
{
}
