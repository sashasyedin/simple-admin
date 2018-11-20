using SimpleAdmin.Common.Redis.Abstractions;
using StackExchange.Redis;

namespace SimpleAdmin.Common.Redis
{
    public class RedisService : BaseRedisService
    {
        public RedisService(IRedisConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public new IDatabase Db => base.Db;
    }
}
