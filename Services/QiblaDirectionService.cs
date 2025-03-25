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

        public async Task<QiblaResponse?> GetQiblaDirection()
        {
            var location = await _prayerTimesService.GetUserLocation();
            if (location == null || location.Lat == 0 || location.Lon == 0)
            {
                Console.WriteLine($"❌ Invalid location: {location?.Lat}, {location?.Lon}");
                return null;
            }

            string cacheKey = $"QiblaDirection-{location.Lat}-{location.Lon}";

            if (_cache.TryGetValue(cacheKey, out QiblaResponse cachedQiblaDirection))
            {
                return cachedQiblaDirection;
            }

            try
            {
                string requestUrl = $"{QiblaApiUrl}/{location.Lat}/{location.Lon}";
                Console.WriteLine($"📍 Fetching Qibla Direction: {requestUrl}");

                var response = await _httpClient.GetFromJsonAsync<QiblaApiResponse>(requestUrl);

                if (response == null)
                {
                    Console.WriteLine("❌ API returned null response.");
                    return null;
                }
                if (response.Data == null)
                {
                    Console.WriteLine("❌ API response does not contain Data.");
                    return null;
                }

                var qiblaDirection = new QiblaResponse { Direction = response.Data.Direction };

                _cache.Set(cacheKey, qiblaDirection, TimeSpan.FromHours(CacheDurationHours));

                return qiblaDirection;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"❌ HTTP Error: {ex.Message}");
                return null;
            }
        }
    }

    public class QiblaApiResponse
    {
        public QiblaResponse Data { get; set; } = new();
    }

    public class QiblaResponse
    {
        public double Direction { get; set; }
    }
}
