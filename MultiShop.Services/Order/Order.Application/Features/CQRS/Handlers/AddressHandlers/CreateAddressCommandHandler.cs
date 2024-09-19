using Order.Application.Features.CQRS.Commands.AddressCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler(IRepository<Address> repository)
{
    private readonly IRepository<Address> _repository = repository;

    public async Task Handle(CreateAddressCommand createAddressCommand)
    => await _repository.CreateAsync(new Address
    {
        City = createAddressCommand.City,
        Detail1 = createAddressCommand.Detail1,
        District = createAddressCommand.District,
        UserId = createAddressCommand.UserId,
        Country = createAddressCommand.Country,
        Description = createAddressCommand.Description,
        Detail2 = createAddressCommand.Detail2,
        Email = createAddressCommand.Email,
        Name = createAddressCommand.Name,
        Phone = createAddressCommand.Phone,
        Surname = createAddressCommand.Surname,
        ZipCode = createAddressCommand.ZipCode
    });

}
