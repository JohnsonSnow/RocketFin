using Application.Features.Transactions.Queries;
using Application.Messaging;

namespace Application.Features.Portfolios.Queries;

public sealed record GetAllPortfoliosQuery(string? symbol, string? SortColumn, string? SortOrder, int Page = 1, int PageSize = 20) : IQuery<PagedList<PortfolioResponse>>
{
}
