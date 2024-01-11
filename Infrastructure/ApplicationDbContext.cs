using Application.Abstractions.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        try
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as IRelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }

    public ApplicationDbContext()
    {

    }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    //protected override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken.None)
    //{
    //    var domainEvents = ChangeTracker.Entries<Entity>()
    //        .Select(e => e.Entity)
    //        .Where(e => e.GetDomainEvents().Any())
    //        .SelectMany(e => e.DomainEvents());

    //    var result = await base.SaveChangesAsync(cancellationToken);

    //    foreach (var domainEvent in domainEvents)
    //    {
    //       //wait _publisher.Publish(domainEvent, cancellationToken);
    //    }

    //    return result;
    //}
}
