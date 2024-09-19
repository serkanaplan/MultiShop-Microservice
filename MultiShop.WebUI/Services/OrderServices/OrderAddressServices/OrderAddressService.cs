using MultiShop.WebUI.DTOs.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

public class OrderAddressService(HttpClient httpClient) : IOrderAddressService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
    {
        await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
    }
}
