using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial(IProductImageService productImageService) : ViewComponent
{
    private readonly IProductImageService _productImageService = productImageService;

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productImageService.GetByProductIdProductImageAsync(id);
        return View(values);
    }
}
