namespace SimpleAdmin.App
{
    public class EnvironmentConfig
    {
        private EnvironmentConfig()
        {
        }

        public bool EnableModelValidation { get; private set; }

        public string RedisConnectionString { get; private set; }

        public string SqlConnectionString { get; private set; }

        private EnvironmentConfig Clone()
        {
            return new EnvironmentConfig()
            {
                EnableModelValidation = EnableModelValidation,
                RedisConnectionString = RedisConnectionString,
                SqlConnectionString = SqlConnectionString
            };
        }

        public class Builder
        {
            private readonly EnvironmentConfig _instance;

            public Builder()
            {
                _instance = new EnvironmentConfig();
            }

            public Builder EnableModelValidation(bool enableModelValidation)
            {
                _instance.EnableModelValidation = enableModelValidation;
                return this;
            }

            public Builder RedisConnectionString(string redisConnectionString)
            {
                _instance.RedisConnectionString = redisConnectionString;
                return this;
            }

            public Builder SqlConnectionString(string sqlConnectionString)
            {
                _instance.SqlConnectionString = sqlConnectionString;
                return this;
            }

            public EnvironmentConfig Build()
            {
                return _instance.Clone();
            }
        }
    }
}
