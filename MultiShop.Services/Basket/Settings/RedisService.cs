using StackExchange.Redis;

namespace Basket.Settings;

public class RedisService(string host, int port)
{
    public string _host { get; set; } = host;
    public int _port { get; set; } = port;

    private ConnectionMultiplexer _connectionMultiplexer;

    public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
}
