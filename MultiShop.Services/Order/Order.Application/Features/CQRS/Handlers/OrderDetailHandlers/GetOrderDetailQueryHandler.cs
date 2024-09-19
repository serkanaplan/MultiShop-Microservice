using Order.Application.Features.CQRS.Results.OrderDetailResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
{
    private readonly IRepository<OrderDetail> _repository = repository;

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            ProductAmount = x.ProductAmount,
            OrderingId = x.OrderingId,
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice
        }).ToList();
    }
}
