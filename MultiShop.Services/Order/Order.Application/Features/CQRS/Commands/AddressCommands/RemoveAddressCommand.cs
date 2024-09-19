namespace Order.Application.Features.CQRS.Commands.AddressCommands;

public class RemoveAddressCommand(int id)
{
    public int Id { get; set; } = id;
}
