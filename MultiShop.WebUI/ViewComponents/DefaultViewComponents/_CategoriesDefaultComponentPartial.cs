using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _CategoriesDefaultComponentPartial(ICategoryService categoryService) : ViewComponent
{
    private readonly ICategoryService _categoryService = categoryService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
}
