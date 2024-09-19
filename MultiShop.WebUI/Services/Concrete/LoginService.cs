using System.Security.Claims;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete;

public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

    public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
}
