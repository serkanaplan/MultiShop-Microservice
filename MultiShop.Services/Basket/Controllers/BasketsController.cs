using Basket.Dtos;
using Basket.LoginServices;
using Basket.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService basketService, ILoginService loginService) : ControllerBase
{
    private readonly IBasketService _basketService = basketService;
    private readonly ILoginService _loginService = loginService;

    [HttpGet]
    public async Task<IActionResult> GetMyBasketDetail()
    {
        var user = User.Claims;
        var values = await _basketService.GetBasket(_loginService.GetUserId);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;
        await _basketService.SaveBasket(basketTotalDto);
        return Ok("Sepetteki değişiklikler kaydedili");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasket(_loginService.GetUserId);
        return Ok("Sepet başarıyla silindi");
    }
}
