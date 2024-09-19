using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailFeatureComponentPartial(IProductService productService) : ViewComponent
{
    private readonly IProductService _productService = productService;

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values=await _productService.GetByIdProductAsync(id);
        return View(values);
    }
}
