using Order.Application.Features.Mediator.Commands.OrderingCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;
using MediatR;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository = repository;

    public async Task<Unit> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId
        });

         return Unit.Value;
    }
}
