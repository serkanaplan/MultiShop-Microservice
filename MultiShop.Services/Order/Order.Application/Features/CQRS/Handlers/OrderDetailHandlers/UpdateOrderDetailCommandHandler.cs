using Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
{
    private readonly IRepository<OrderDetail> _repository = repository;

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var values = await _repository.GetByIdAsync(command.OrderDetailId);
        values.OrderingId = command.OrderingId;
        values.ProductId = command.ProductId;
        values.ProductPrice = command.ProductPrice;
        values.ProductName = command.ProductName;
        values.ProductTotalPrice = command.ProductTotalPrice;
        values.ProductAmount = command.ProductAmount;
        await _repository.UpdateAsync(values);
    }
}
