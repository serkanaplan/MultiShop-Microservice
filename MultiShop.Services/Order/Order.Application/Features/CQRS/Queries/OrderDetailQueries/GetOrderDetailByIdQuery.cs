namespace Order.Application.Features.CQRS.Queries.OrderDetailQueries;

public class GetOrderDetailByIdQuery(int id)
{
    public int Id { get; set; } = id;
}
