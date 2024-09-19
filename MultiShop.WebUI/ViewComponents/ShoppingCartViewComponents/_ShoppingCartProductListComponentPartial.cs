using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartProductListComponentPartial(IBasketService basketService) : ViewComponent
{
    private readonly IBasketService _basketService = basketService;

    public async Task< IViewComponentResult> InvokeAsync()
    {
        var basketTotal = await _basketService.GetBasket();
        var basketItems = basketTotal.BasketItems;
        return View(basketItems);
    }
}
