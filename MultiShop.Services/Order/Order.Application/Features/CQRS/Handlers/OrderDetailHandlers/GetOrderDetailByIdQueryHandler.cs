using Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Order.Application.Features.CQRS.Results.OrderDetailResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
{
    private readonly IRepository<OrderDetail> _repository = repository;

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = values.OrderDetailId,
            ProductAmount = values.ProductAmount,
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            OrderingId = values.OrderingId,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice
        };
    }
}
