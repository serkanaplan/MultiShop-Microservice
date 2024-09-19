using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete;

public class UserService(HttpClient httpClient) : IUserService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
    }
}
