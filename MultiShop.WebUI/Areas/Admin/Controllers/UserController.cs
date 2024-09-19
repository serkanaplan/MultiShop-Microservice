using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService) : Controller
{
    private readonly IUserIdentityService _userIdentityService = userIdentityService;
    private readonly ICargoCustomerService _cargoCustomerService = cargoCustomerService;

    public async Task<IActionResult> UserList()
    {
        var values = await _userIdentityService.GetAllUserListAsync();
        return View(values);
    }

    public async Task<IActionResult> UserAddressInfo(string id)
    {
        var values =await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
        return View(values);
    }
}
