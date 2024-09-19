using Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
{
    private readonly IRepository<OrderDetail> _repository = repository;

    public async Task Handle(CreateOrderDetailCommand command)
     => await _repository.CreateAsync(new OrderDetail
     {
         ProductAmount = command.ProductAmount,
         OrderingId = command.OrderingId,
         ProductId = command.ProductId,
         ProductName = command.ProductName,
         ProductPrice = command.ProductPrice,
         ProductTotalPrice = command.ProductTotalPrice
     });
}
