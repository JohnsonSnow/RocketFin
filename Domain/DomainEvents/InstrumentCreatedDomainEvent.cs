using SharedKernel;

namespace Domain.DomainEvents;

public sealed record InstrumentCreatedDomainEvent(Guid instrumentId) : IDomainEvent
{
}
