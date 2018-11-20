using StackExchange.Redis;

namespace SimpleAdmin.Common.Redis.Abstractions
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection { get; }
    }
}
