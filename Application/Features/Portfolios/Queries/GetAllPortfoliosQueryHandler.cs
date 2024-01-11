using Application.Features.Transactions.Queries;
using Application.Messaging;
using Application.Repositories;
using Application.Services;
using Domain.Entities;
using MediatR;
using SharedKernel;

namespace Application.Features.Portfolios.Queries;

internal sealed class GetAllPortfoliosQueryHandler : IQueryHandler<GetAllPortfoliosQuery, PagedList<PortfolioResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly FinanceApiService _financeApiService;

    public GetAllPortfoliosQueryHandler(ITransactionRepository transactionRepository, FinanceApiService financeApiService)
    {
        _transactionRepository = transactionRepository;
        _financeApiService = financeApiService;
    }

    public async Task<Result<PagedList<PortfolioResponse>>> Handle(GetAllPortfoliosQuery request, CancellationToken cancellationToken)
    {
        var transactions = _transactionRepository.GetAllAsync("", "", "", Page: 1, PageSize: 200, cancellationToken);

        Portfolio myPortfolio = new Portfolio();
        foreach (var transaction in transactions.Result.Items)
        {
            myPortfolio.AddTransaction(transaction);
        }
        List<PortfolioResponse> portfolios = new List<PortfolioResponse>();


        foreach (var holding in myPortfolio.Holdings)
        {
            var apiResponse = await _financeApiService.GetQuoteAsync(holding.Key, cancellationToken);
            decimal regularMarketPrice = (decimal)apiResponse.quoteResponse.result[0].regularMarketPrice;
            myPortfolio.AddCurrentMarketValue(regularMarketPrice);
            var item = new PortfolioResponse(holding.Key, myPortfolio.CalculateCostBasis(), myPortfolio.CalculateMarketValue(), myPortfolio.CalculateUnrealizedReturnRate(), myPortfolio.CalculateUnrealizedProfitLoss());
            portfolios.Add(item);
        }

        var response = await PagedList<PortfolioResponse>.CreateListAsync(portfolios, request.Page, request.PageSize);

        return response;
    }
}
