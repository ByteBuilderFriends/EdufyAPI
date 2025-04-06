using EdufyAPI.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace EdufyAPI.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetDataAsync<T>(string key)
        {
            try
            {
                if (_memoryCache.TryGetValue(key, out T value))
                {
                    return value;
                }

                return default;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime)
        {
            try
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(expirationTime);

                _memoryCache.Set(key, value, cacheEntryOptions);
                return await Task.FromResult(true); // Just to simulate async, return true.
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveDataAsync(string key)
        {
            try
            {
                _memoryCache.Remove(key);
                await Task.CompletedTask; // Just to simulate async.
            }
            catch
            {
                throw;
            }
        }
    }
}
