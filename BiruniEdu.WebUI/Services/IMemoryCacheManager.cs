using Microsoft.Extensions.Caching.Memory;

namespace BiruniEdu.WebUI.Services
{
    public class MemoryCacheManager:ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<T>(string key, T data)
        {
            _memoryCache.Set(key, data);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
