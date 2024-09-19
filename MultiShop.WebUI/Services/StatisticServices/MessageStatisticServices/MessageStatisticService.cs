
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;

public class MessageStatisticService(HttpClient httpClient) : IMessageStatisticService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<int> GetTotalMessageCount()
    {
        var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }
}
