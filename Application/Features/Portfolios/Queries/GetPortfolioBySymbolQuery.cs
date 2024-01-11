using Application.Messaging;

namespace Application.Features.Portfolios.Queries;

public sealed record GetPortfolioBySymbolQuery(string symbol) : IQuery<PortfolioResponse>
{
}
