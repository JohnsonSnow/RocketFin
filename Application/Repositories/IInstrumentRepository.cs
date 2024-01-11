using Domain.Entities;

namespace Application.Repositories;

public interface IInstrumentRepository
{
    Task<Instrument?> GetInstrumentBySymbol(string symbol);
}
