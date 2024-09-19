using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _VendorDefaultComponentPartial(IBrandService brandService) : ViewComponent
{
    private readonly IBrandService _brandService = brandService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _brandService.GetAllBrandAsync();
        return View(values);
    }
}
