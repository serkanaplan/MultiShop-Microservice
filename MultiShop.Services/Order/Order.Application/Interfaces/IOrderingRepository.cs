using Order.Domain.Entities;

namespace Order.Application.Interfaces;

public interface IOrderingRepository
{
    public List<Ordering> GetOrderingsByUserId(string id);
}
