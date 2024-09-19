using MediatR;
using Order.Application.Features.Mediator.Queries.OrderingQueries;
using Order.Application.Features.Mediator.Results.OrderingResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _repository = repository;

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult
        {
            OrderDate = values.OrderDate,
            OrderingId = values.OrderingId,
            TotalPrice = values.TotalPrice,
            UserId = values.UserId
        };
    }
}
