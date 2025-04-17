using Newtonsoft.Json;
using StackExchange.Redis;

namespace BiruniEdu.WebUI.Services
{
    public class RedisCacheManager:ICacheManager
    {
        public RedisCacheManager()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
            RedisCache = _connectionMultiplexer.GetDatabase(0);
        }

        private ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase RedisCache { get; set; }

        public void Set<T>(string key, T data)
        {

            var serializedStr = JsonConvert.SerializeObject(data, Formatting.Indented);

            //_memoryCache.Set("facultyList", liveData);
            RedisCache.StringSet(key, serializedStr, TimeSpan.FromHours(60));
        }

        public T Get<T>(string key)
        {
            var cachedDataStr = RedisCache.StringGet(key);

            if (!cachedDataStr.IsNull)
            {
                var cachedData = JsonConvert.DeserializeObject<T>(cachedDataStr);

                return cachedData;

            }

            return default(T);
        }
    }
}
