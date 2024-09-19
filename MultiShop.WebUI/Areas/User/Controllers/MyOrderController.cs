using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
public class MyOrderController(IOrderOderingService orderOderingService, IUserService userService) : Controller
{
    private readonly IOrderOderingService _orderOderingService = orderOderingService;
    private readonly IUserService _userService = userService;

    public async Task<IActionResult> MyOrderList()
    {
        var user = await _userService.GetUserInfo();
        var values = await _orderOderingService.GetOrderingByUserId(user.Id);
        return View(values);
    }
}
