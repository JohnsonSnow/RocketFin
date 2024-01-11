using Application.Messaging;

namespace Application.Features.Investment.Queries.GetStockByInstrumentTickerId;

public sealed record GetStockInstrumentByTickerIdQuery(string TickerId) : IQuery<FinanceApiResponse>
{
}

