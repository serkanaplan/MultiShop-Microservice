using Order.Application.Features.CQRS.Queries.AddressQueries;
using Order.Application.Features.CQRS.Results.AddressResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler(IRepository<Address> repository)
{
    private readonly IRepository<Address> _repository = repository;

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetAddressByIdQueryResult
        {
            AddressId = values.AddressId,
            City = values.City,
            Detail = values.Detail1,
            District = values.District,
            UserId = values.UserId
        };
    }
}
