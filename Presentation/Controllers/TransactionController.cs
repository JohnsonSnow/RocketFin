using Application.Features.Transactions.Commands.Create;
using Application.Features.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;
using SharedKernel;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public sealed class TransactionController : ApiController
{
    public TransactionController(ISender sender) : base(sender)
    {
    }

    [HttpPost(nameof(PurchaseShares))]
    public async Task<IActionResult> PurchaseShares([FromBody] CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var command = new CreateTransactionCommand(request.symbol, request.numberOfShares);
         await Sender.Send(command);

        return Ok();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetAllTransactions))]
    [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllTransactions([FromQuery] GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var query = new GetAllTransactionsQuery(request.symbol, request.SortColumn, request.SortOrder, request.Page, request.PageSize);
        var result = await Sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
