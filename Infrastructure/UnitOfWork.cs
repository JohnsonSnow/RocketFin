﻿
using Application.Abstractions.Data;

namespace Infrastructure;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       return _context.SaveChangesAsync(cancellationToken);
    }
}
