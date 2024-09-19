using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.DTOs.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers;

public class LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService) : Controller
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IIdentityService _identityService = identityService;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SignInDto signInDto)
    {
        await _identityService.SignIn(signInDto);
        return RedirectToAction("Index", "User");
    }
}
