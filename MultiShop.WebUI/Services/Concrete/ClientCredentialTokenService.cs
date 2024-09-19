using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete;

public class ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings) : IClientCredentialTokenService
{
    private readonly ServiceApiSettings _serviceApiSettings = serviceApiSettings.Value;
    private readonly HttpClient _httpClient = httpClient;
    private readonly IClientAccessTokenCache _clientAccessTokenCache = clientAccessTokenCache;
    private readonly ClientSettings _clientSettings = clientSettings.Value;

    public async Task<string> GetToken()
    {
        var token1 = await _clientAccessTokenCache.GetAsync("multishoptoken", new ClientAccessTokenParameters(), CancellationToken.None);
        if (token1 != null)
        {
            return token1.AccessToken;
        }
        var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
            ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
            Address = discoveryEndPoint.TokenEndpoint
        };

        var token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
        var parameters = new ClientAccessTokenParameters();
        await _clientAccessTokenCache.SetAsync("multishoptoken", token2.AccessToken, token2.ExpiresIn, parameters);
        return token2.AccessToken;
    }
}
