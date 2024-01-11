using Domain.Entities;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Transactions.Queries;
using Application.Features.Portfolios.Queries;

namespace Infrastructure.Repositories
{
    internal sealed class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<PagedList<PortfolioResponse>> GetAllPortfolios()
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio?> GetPortfolio(Guid id)
        {
            //return _context.Portfolios.SingleOrDefaultAsync(p => p.Id == id);
            return (Task<Portfolio?>)Task.CompletedTask;
        }
    }
}
