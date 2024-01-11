using Application.Abstractions.Data;
using Application.Services;
using Domain.Entities;
using Application.Repositories;
using MediatR;

namespace Application.Features.Transactions.Commands.Create;

internal sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly FinanceApiService _financeApiService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, FinanceApiService financeApiService)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
        _financeApiService = financeApiService;
    }

    public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var response = await _financeApiService.GetQuoteAsync(request.symbol, cancellationToken);
       
        foreach (var item in response.quoteResponse.result)
        {
            var transaction = Transaction.Create(
                request.symbol, 
                item.shortName, 
                item.longName, 
                (decimal)item.bid, 
                (decimal)item.ask, 
                (decimal)item.regularMarketPrice, 
                (decimal)item.regularMarketDayHigh, 
                (decimal)item.regularMarketDayLow, 
                (decimal)item.regularMarketChange, 
                (decimal)item.regularMarketChangePercent, 
                (decimal)item.regularMarketOpen, 
                request.numberOfShares, 
                (decimal)item.regularMarketPrice, 
                DateTime.UtcNow);

            _transactionRepository.CreateAsync(transaction);
          
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
