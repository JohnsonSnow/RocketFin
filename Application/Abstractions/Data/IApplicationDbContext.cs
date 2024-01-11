
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Transaction> Transactions { get; set; }

  //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
