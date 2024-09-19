namespace Basket.LoginServices;

public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
{
    private readonly IHttpContextAccessor _httpContextAccessor = contextAccessor;

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
}
