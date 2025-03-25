using Microsoft.Extensions.Caching.Memory;

namespace EdufyAPI.Services
{
    public class PrayerTimesService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string GeoApiUrl = "http://ip-api.com/json/";
        private const string PrayerApiUrl = "https://api.aladhan.com/v1/timings";
        private const int CacheDurationHours = 24; // Cache prayer times for 24 hours
        private const int LocationCacheDurationMinutes = 60; // Cache location for 1 hour

        public PrayerTimesService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        // ✅ Get and cache user location
        public async Task<GeoLocationResponse> GetUserLocation()
        {
            const string cacheKey = "UserLocation";

            // ✅ Check if location is already cached
            if (_cache.TryGetValue(cacheKey, out GeoLocationResponse cachedLocation))
            {
                return cachedLocation;
            }

            var response = await _httpClient.GetFromJsonAsync<GeoLocationResponse>(GeoApiUrl);
            var location = response ?? new GeoLocationResponse();

            // ✅ Store in cache for 1 hour
            _cache.Set(cacheKey, location, TimeSpan.FromMinutes(LocationCacheDurationMinutes));

            return location;
        }

        // ✅ Get and cache prayer times
        public async Task<PrayerTimesResponse> GetPrayerTimes()
        {
            var location = await GetUserLocation();
            string cacheKey = $"PrayerTimes_{location.Lat}_{location.Lon}";

            // ✅ Check if prayer times are already cached
            if (_cache.TryGetValue(cacheKey, out PrayerTimesResponse cachedPrayerTimes))
            {
                return cachedPrayerTimes;
            }

            var response = await _httpClient.GetFromJsonAsync<PrayerTimesResponse>(
                $"{PrayerApiUrl}?latitude={location.Lat}&longitude={location.Lon}&method=2"
            );

            var prayerTimes = response ?? new PrayerTimesResponse();

            // ✅ Store in cache for 24 hours
            _cache.Set(cacheKey, prayerTimes, TimeSpan.FromHours(CacheDurationHours));

            return prayerTimes;
        }

        // Models
        public class GeoLocationResponse
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
            public string Country { get; set; } = "Unknown";
            public string City { get; set; } = "Unknown";
        }

        public class PrayerTimesResponse
        {
            public PrayerTimings Data { get; set; }
        }

        public class PrayerTimings
        {
            public Dictionary<string, string> Timings { get; set; } // Prayer : Time
        }
    }
}
