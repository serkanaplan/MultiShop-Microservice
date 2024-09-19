using Order.Application.Features.CQRS.Commands.AddressCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler(IRepository<Address> repository)
{
    private readonly IRepository<Address> _repository = repository;

    public async Task Handle(UpdateAddressCommand command)
    {
        var values = await _repository.GetByIdAsync(command.AddressId);
        values.Detail1 = command.Detail;
        values.District = command.District;
        values.City = command.City;
        values.UserId = command.UserId;
        await _repository.UpdateAsync(values);
    }
}