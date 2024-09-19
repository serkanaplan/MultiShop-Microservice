namespace Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public class RemoveOrderDetailCommand(int id)
{
    public int Id { get; set; } = id;
}
