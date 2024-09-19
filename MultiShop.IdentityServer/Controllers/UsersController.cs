using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Controllers;

[Authorize(LocalApi.PolicyName)]

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
        var user = await _userManager.FindByIdAsync(userClaim.Value);
        return Ok(new
        {
            user.Id,
            user.Name,
            user.Surname,
            user.Email,
            user.UserName
        });
    }

    [HttpGet("GetAllUserList")]
    public async Task<IActionResult> GetAllUserList()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }
}
