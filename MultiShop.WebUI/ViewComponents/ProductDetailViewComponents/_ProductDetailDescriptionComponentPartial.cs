using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService) : ViewComponent
{
    private readonly IProductDetailService _productDetailService = productDetailService;

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
        return View(values);
    }
}