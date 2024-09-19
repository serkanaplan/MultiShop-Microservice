using Order.Application.Features.CQRS.Commands.AddressCommands;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler(IRepository<Address> repository)
{
    private readonly IRepository<Address> _repository = repository;

    public async Task Handle(RemoveAddressCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        await _repository.DeleteAsync(value);
    }
}
