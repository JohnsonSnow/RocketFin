using Application.Messaging;
using SharedKernel;

namespace Application.Features.Portfolios.Queries;

internal sealed class GetPortfolioBySymbolQueryHandler : IQueryHandler<GetPortfolioBySymbolQuery, PortfolioResponse>
{
    public Task<Result<PortfolioResponse>> Handle(GetPortfolioBySymbolQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
