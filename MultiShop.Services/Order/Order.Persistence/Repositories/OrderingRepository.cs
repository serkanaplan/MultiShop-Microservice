using Order.Application.Interfaces;
using Order.Domain.Entities;
using Order.Persistence.Context;

namespace Order.Persistence.Repositories;

public class OrderingRepository(OrderContext orderContext) : IOrderingRepository
{
    private readonly OrderContext _orderContext = orderContext;

    public List<Ordering> GetOrderingsByUserId(string id)
    => [.. _orderContext.Orderings.Where(x => x.UserId == id)];
}
