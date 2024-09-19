namespace SignalR.Services.SignalRCommentServices;

public interface ISignalRCommentService
{
    Task<int> GetTotalCommentCount();
}
