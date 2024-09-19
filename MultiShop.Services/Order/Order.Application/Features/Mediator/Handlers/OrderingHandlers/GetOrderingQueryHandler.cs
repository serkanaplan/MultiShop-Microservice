using MediatR;
using Order.Application.Features.Mediator.Queries.OrderingQueries;
using Order.Application.Features.Mediator.Results.OrderingResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _repository = repository;

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId
        }).ToList();
    }
}
