using MediatR;
using Order.Application.Features.Mediator.Commands.OrderingCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class RemoveOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<RemoveOrderingCommand>
{
    private readonly IRepository<Ordering> _repository = repository;

    public async Task<Unit> Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(values);
         return Unit.Value;
    }
}
