using SimpleAdmin.Common.Redis.Abstractions;
using SimpleAdmin.Utils;
using StackExchange.Redis;
using System;

namespace SimpleAdmin.Common.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        public RedisConnectionFactory(string connectionString)
        {
            Assert.NotNullOrEmpty(connectionString, nameof(connectionString));

            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
        }

        public ConnectionMultiplexer Connection => _connection.Value;
    }
}
