using Basket.Dtos;
using Basket.Settings;
using System.Text.Json;

namespace Basket.Services;

public class BasketService(RedisService redisService) : IBasketService
{
    private readonly RedisService _redisService = redisService;

    public async Task DeleteBasket(string userId) 
    => await _redisService.GetDb().KeyDeleteAsync(userId);

    public async Task<BasketTotalDto> GetBasket(string userId) 
    => JsonSerializer.Deserialize<BasketTotalDto>(await _redisService.GetDb().StringGetAsync(userId));

    public async Task SaveBasket(BasketTotalDto basketTotalDto) 
    => await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
}