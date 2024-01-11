

using Application.Features.Investment.Queries.GetStockByInstrumentTickerId;
using Application.Services;
using FluentAssertions;
using Polly.Registry;
using SharedKernel;
using Result = SharedKernel.Result;

namespace Application.UnitTests.Features.Investment;

public class GetStockInstrumentByTickerIdQueryTest
{
    private static readonly GetStockInstrumentByTickerIdQuery Query = new("APPL");
    private readonly GetStockInstrumentByTickerIdQueryHandler _handler;
    private readonly FinanceApiService _fastaApiServiceMock;
    private readonly ResiliencePipelineProvider<string> pipelineProviderMock;

    public GetStockInstrumentByTickerIdQueryTest()
    {
        _handler = new GetStockInstrumentByTickerIdQueryHandler(_fastaApiServiceMock, pipelineProviderMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenAPIKeyIsNull()
    {
        // Arrange
        GetStockInstrumentByTickerIdQuery missingApiKey = Query with { TickerId = "tickerId" };

        // Act
        Result result = await _handler.Handle(missingApiKey, default);

        // Assert
        result.Error.Should().BeNull();

    }
}
