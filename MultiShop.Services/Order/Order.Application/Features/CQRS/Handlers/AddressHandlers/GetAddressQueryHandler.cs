using Order.Application.Features.CQRS.Results.AddressResults;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler(IRepository<Address> repository)
{
    private readonly IRepository<Address> _repository = repository;

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            City = x.City,
            Detail = x.Detail1,
            District = x.District,
            UserId = x.UserId
        }).ToList();
    }
}
