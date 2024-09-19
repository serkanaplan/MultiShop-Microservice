
namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;

public class DiscountStatisticService(HttpClient httpClient) : IDiscountStatisticService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<int> GetDiscountCouponCount()
    {
        var responseMessage = await _httpClient.GetAsync("Discounts/GetDiscountCouponCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }
}
