using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService) : ViewComponent
{
    private readonly IOfferDiscountService _offerDiscountService = offerDiscountService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _offerDiscountService.GetAllOfferDiscountAsync();
        return View(values);
    }
}
