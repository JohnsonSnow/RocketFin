using Domain.Entities;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class InstrumentRepository : IInstrumentRepository
{
    private readonly ApplicationDbContext _context;

    public InstrumentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Instrument?> GetInstrumentBySymbol(string symbol)
    {
        //return _context.Instruments.SingleOrDefaultAsync(i => i.Symbol == symbol);
        throw new NotImplementedException();
    }
}
