using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureDefaultComponentPartial(IFeatureService featureService) : ViewComponent
{
    private readonly IFeatureService _featureService = featureService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _featureService.GetAllFeatureAsync();
        return View(values);
    }
}
