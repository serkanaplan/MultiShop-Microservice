using IdentityServer.Models;
using IdentityServer.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;

namespace MultiShop.IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
        var user = await _userManager.FindByNameAsync(userLoginDto.Username);

        if (result.Succeeded)
        {
            GetCheckAppUserViewModel model = new()
            {
                Username = userLoginDto.Username,
                Id = user.Id
            };
            var token = JwtTokenGenerator.GenerateToken(model);
            return Ok(token);
        }
        else
        {
            return Ok("Kullanıcı Adı veya Şifre Hatalı");
        }
    }
}
