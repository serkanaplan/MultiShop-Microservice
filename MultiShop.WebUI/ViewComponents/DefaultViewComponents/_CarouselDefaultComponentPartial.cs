using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService) : ViewComponent
{
    private readonly IFeatureSliderService _featureSliderService = featureSliderService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values =await _featureSliderService.GetAllFeatureSliderAsync();
        return View(values);
    }
}
