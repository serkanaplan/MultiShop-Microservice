using MediatR;
using Order.Application.Features.Mediator.Results.OrderingResults;

namespace Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{
}
