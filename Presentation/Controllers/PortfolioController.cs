using Application.Features.Portfolios.Queries;
using Application.Features.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;
using SharedKernel;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public sealed class PortfolioController : ApiController
{
    public PortfolioController(ISender sender) : base(sender)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="sortColumn"></param>
    /// <param name="sortOrder"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet(nameof(GetPortfolio))]
    [ProducesResponseType(typeof(Result<PortfolioResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPortfolio([FromQuery] GetAllPortfoliosQuery request, CancellationToken cancellationToken)
    {
        var query = new GetAllPortfoliosQuery(request.symbol, request.SortColumn, request.SortOrder, request.Page, request.PageSize);
        var result = await Sender.Send(query, cancellationToken);
        return Ok(result);
    }
}
