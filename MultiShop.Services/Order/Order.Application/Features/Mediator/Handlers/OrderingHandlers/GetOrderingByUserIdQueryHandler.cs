using MediatR;
using Order.Application.Features.Mediator.Queries.OrderingQueries;
using Order.Application.Features.Mediator.Results.OrderingResults;
using Order.Application.Interfaces;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository) : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IOrderingRepository _orderingRepository = orderingRepository;

    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = _orderingRepository.GetOrderingsByUserId(request.Id);
        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            OrderDate = x.OrderDate,
            OrderingId = x.OrderingId,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId
        }).ToList();
    }
}
