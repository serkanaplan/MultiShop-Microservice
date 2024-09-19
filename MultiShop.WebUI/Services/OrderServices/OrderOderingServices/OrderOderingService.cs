using MultiShop.WebUI.DTOs.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOderingServices;

public class OrderOderingService(HttpClient httpClient) : IOrderOderingService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
    {
        //$"products/ProductListWithCategoryByCategoryId/{CategoryId}"
        var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
        return values;
    }
}
