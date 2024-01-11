using Application.Messaging;
using Application.Repositories;
using SharedKernel;

namespace Application.Features.Transactions.Queries;

internal sealed class GetAllTransactionsQueryHandler : IQueryHandler<GetAllTransactionsQuery, PagedList<TransactionResponse>>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Result<PagedList<TransactionResponse>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var response = await _transactionRepository.GetAllAsync(request.symbol, request.SortColumn, request.SortOrder, request.Page, request.PageSize, cancellationToken);
        if(response is null)
        {
            return Result.Failure<PagedList<TransactionResponse>>(new Error("Transaction.NotFound", "Transaction not found"));
        }
        return response;
    }
}
