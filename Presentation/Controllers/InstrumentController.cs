using Application.Features.Investment.Queries.GetStockByInstrumentTickerId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controllers;

[Route("api/[controller]")]
public sealed class InstrumentController : ApiController
{
    public InstrumentController(ISender sender) : base(sender)
    {
    }

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetInstrumentInfo(string symbol)
    {
        var query = new GetStockInstrumentByTickerIdQuery(symbol);
        var result = await Sender.Send(query);
        return Ok(result);

    }

}
