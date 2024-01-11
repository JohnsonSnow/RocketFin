using Application.Messaging;
using MediatR;

namespace Application.Features.Transactions.Commands.Create;

public record CreateTransactionCommand(string symbol, int numberOfShares) : IRequest
{
}
