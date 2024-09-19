using Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(IStatisticService statisticService) : ControllerBase
{
    private readonly IStatisticService _statisticService = statisticService;

    [HttpGet("GetBrandCount")]
    public async Task<IActionResult> GetBrandCount()
    {
        var value = await _statisticService.GetBrandCount();
        return Ok(value);
    }

    [HttpGet("GetCategoryCount")]
    public async Task<IActionResult> GetCategoryCount()
    {
        var value = await _statisticService.GetCategoryCount();
        return Ok(value);
    }

    [HttpGet("GetProductCount")]
    public async Task<IActionResult> GetProductCount()
    {
        var value = await _statisticService.GetProductCount();
        return Ok(value);
    }

    [HttpGet("GetProductAvgPrice")]
    public async Task<IActionResult> GetProductAvgPrice()
    {
        var value = await _statisticService.GetProductAvgPrice();
        return Ok(value);
    }


    [HttpGet("GetMaxPriceProductName")]
    public async Task<IActionResult> GetMaxPriceProductName()
    {
        var value = await _statisticService.GetMaxPriceProductName();
        return Ok(value);
    }

    [HttpGet("GetMinPriceProductName")]
    public async Task<IActionResult> GetMinPriceProductName()
    {
        var value = await _statisticService.GetMinPriceProductName();
        return Ok(value);
    }
}
