using SharedKernel;

namespace Domain.DomainEvents;

public sealed record PortfolioCreatedDomainEvent(Guid portfolioId) : IDomainEvent
{
}
