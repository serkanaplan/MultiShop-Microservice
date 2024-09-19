using MultiShop.WebUI.DTOs.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOderingServices;

public interface IOrderOderingService
{
    Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
}
