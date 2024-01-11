using Application.Messaging;
using Application.Services;
using Polly;
using Polly.Registry;
using SharedKernel;

namespace Application.Features.Investment.Queries.GetStockByInstrumentTickerId;

internal sealed class GetStockInstrumentByTickerIdQueryHandler 
    : IQueryHandler<GetStockInstrumentByTickerIdQuery, FinanceApiResponse>
{
    private readonly FinanceApiService _financeApiService;
    private readonly ResiliencePipelineProvider<string> pipelineProvider;

    public GetStockInstrumentByTickerIdQueryHandler(FinanceApiService financeApiService, ResiliencePipelineProvider<string> pipelineProvider)
    {
        _financeApiService = financeApiService;
        this.pipelineProvider = pipelineProvider;
    }

    public async Task<Result<FinanceApiResponse>> Handle(
        GetStockInstrumentByTickerIdQuery request, 
        CancellationToken cancellationToken)
    {
        var pipeline = pipelineProvider.GetPipeline<FinanceApiResponse?>("finance-api-pipeline");

       return await pipeline.ExecuteAsync(async token => await _financeApiService.GetQuoteAsync(request.TickerId, token), cancellationToken);
    }
}
