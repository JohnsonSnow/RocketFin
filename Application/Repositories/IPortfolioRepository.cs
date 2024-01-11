using Application.Features.Portfolios.Queries;
using Application.Features.Transactions.Queries;
using Domain.Entities;

namespace Application.Repositories;

public interface IPortfolioRepository
{
    Task<Portfolio?> GetPortfolio(Guid id);
    Task<PagedList<PortfolioResponse>> GetAllPortfolios();
}
