using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;

namespace IdentityServer.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class RegistersController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpPost]
    public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
    {
        var values = new ApplicationUser()
        {
            UserName = userRegisterDto.Username,
            Email = userRegisterDto.Email,
            Name = userRegisterDto.Name,
            Surname = userRegisterDto.Surname
        };
        var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
        
        if (result.Succeeded)return Ok("Kullanıcı başarıyla eklendi");
        else return Ok("Bir hata oluştu tekrar deneyiniz");
    }
}
