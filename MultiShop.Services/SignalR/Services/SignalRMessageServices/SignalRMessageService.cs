namespace SignalR.Services.SignalRMessageServices;

public class SignalRMessageService(HttpClient httpClient) : ISignalRMessageService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<int> GetTotalMessageCountByReceiverId(string id)
    {
        var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageCountByReceiverId?id=" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }
}
