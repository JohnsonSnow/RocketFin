using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Portfolios.Queries
{
    public sealed record PortfolioResponse(string symbol, decimal costBasis, decimal marketValue, decimal unrealizedReturnRate, decimal unrealizedProfitLoss)
    {
    }
}
