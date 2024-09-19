using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.DTOs.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers;

public class OrderController(IOrderAddressService orderAddressService, IUserService userService) : Controller
{
    private readonly IOrderAddressService _orderAddressService = orderAddressService;
    private readonly IUserService _userService = userService;

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.directory1 = "MultiShop";
        ViewBag.directory2 = "Siparişler";
        ViewBag.directory3 = "Sipariş İşlemleri";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
    {
        var values = await _userService.GetUserInfo();
        createOrderAddressDto.UserId = values.Id;
        createOrderAddressDto.Description = "aa";

        await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

        return RedirectToAction("Index", "Payment");
    }
}
