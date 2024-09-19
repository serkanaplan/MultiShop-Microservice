using MediatR;
using Order.Application.Features.Mediator.Commands.OrderingCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository = repository;

    public async Task<Unit> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.OrderingId);
        values.OrderDate = request.OrderDate;
        values.UserId = request.UserId;
        values.TotalPrice = request.TotalPrice;
        await _repository.UpdateAsync(values);
        return Unit.Value;
    }
}
