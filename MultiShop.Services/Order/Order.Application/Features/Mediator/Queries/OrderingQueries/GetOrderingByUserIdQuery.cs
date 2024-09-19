using MediatR;
using Order.Application.Features.Mediator.Results.OrderingResults;

namespace Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByUserIdQuery(string id) : IRequest<List<GetOrderingByUserIdQueryResult>>
{
    public string Id { get; set; } = id;
}
