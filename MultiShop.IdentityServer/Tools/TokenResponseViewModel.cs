namespace IdentityServer.Tools;

public class TokenResponseViewModel(string token, DateTime expireDate)
{
    public string Token { get; set; } = token;
    public DateTime ExpireDate { get; set; } = expireDate;
}
