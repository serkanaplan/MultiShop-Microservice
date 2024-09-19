using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _SpeacialOfferComponentPartial(ISpecialOfferService specialOfferService) : ViewComponent
{
    private readonly ISpecialOfferService _specialOfferService = specialOfferService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(values);
    }
}
