using SimpleAdmin.Common.Redis.Abstractions;
using SimpleAdmin.Utils;
using StackExchange.Redis;

namespace SimpleAdmin.Common.Redis
{
    public abstract class BaseRedisService
    {
        protected BaseRedisService(IRedisConnectionFactory connectionFactory)
        {
            Assert.NotNull(connectionFactory, nameof(connectionFactory));

            Db = connectionFactory.Connection.GetDatabase();
        }

        protected IDatabase Db { get; }
    }
}
