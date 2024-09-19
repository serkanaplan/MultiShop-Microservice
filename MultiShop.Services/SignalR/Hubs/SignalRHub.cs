using Microsoft.AspNetCore.SignalR;
using SignalR.Services.SignalRCommentServices;

namespace SignalR.Hubs;

public class SignalRHub(ISignalRCommentService signalRCommentService) : Hub
{
    private readonly ISignalRCommentService _signalRCommentService = signalRCommentService;

    public async Task SendStatisticCount()
    {
        var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
        await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);
    }
}
