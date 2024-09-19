using MediatR;
using Order.Application.Features.Mediator.Results.OrderingResults;

namespace Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByIdQuery(int id) : IRequest<GetOrderingByIdQueryResult>
{
    public int Id { get; set; } = id;
}
