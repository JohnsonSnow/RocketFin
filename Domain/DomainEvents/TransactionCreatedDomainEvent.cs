using SharedKernel;

namespace Domain.DomainEvents;

public sealed record TransactionCreatedDomainEvent(Guid transactionId) : IDomainEvent
{
}
