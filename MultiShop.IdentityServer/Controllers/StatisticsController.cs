using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpGet]
    public IActionResult GetUserCount()
    {
        int usercount = _userManager.Users.Count();
        return Ok(usercount);
    }
}
