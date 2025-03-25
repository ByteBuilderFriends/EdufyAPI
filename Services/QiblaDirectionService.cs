using Microsoft.Extensions.Caching.Memory;

namespace EdufyAPI.Services
{
    public class QiblaDirectionService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly PrayerTimesService _prayerTimesService;
        private const string QiblaApiUrl = "https://api.aladhan.com/v1/qibla";
        private const int CacheDurationHours = 24; // Cache for 24 hours

        public QiblaDirectionService(HttpClient httpClient, IMemoryCache cache, PrayerTimesService prayerTimesService)
        {
            _httpClient = httpClient;
            _cache = cache;
            _prayerTimesService = prayerTimesService;
        }

        // ✅ Get Qibla Compass Image
        public async Task<QiblaCompassResponse?> GetQiblaCompass()
        {
            var location = await _prayerTimesService.GetUserLocation();
            if (location == null || location.Lat == 0 || location.Lon == 0)
            {
                Console.WriteLine($"❌ Invalid location: {location?.Lat}, {location?.Lon}");
                return null;
            }

            string cacheKey = $"QiblaCompass-{location.Lat}-{location.Lon}";

            if (_cache.TryGetValue(cacheKey, out QiblaCompassResponse cachedCompass))
            {
                return cachedCompass;
            }

            try
            {
                string requestUrl = $"{QiblaApiUrl}/{location.Lat}/{location.Lon}/image";
                Console.WriteLine($"📍 Fetching Qibla Compass Image: {requestUrl}");

                var compassImageUrl = new QiblaCompassResponse { ImageUrl = requestUrl };

                _cache.Set(cacheKey, compassImageUrl, TimeSpan.FromHours(CacheDurationHours));

                return compassImageUrl;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"❌ HTTP Error: {ex.Message}");
                return null;
            }
        }
    }

    public class QiblaCompassResponse
    {
        public string ImageUrl { get; set; } = string.Empty;
    }
}
