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

        // ✅ Get and cache user location using their IP
        public async Task<GeoLocationResponse> GetUserLocationAsync(string userIp)
        {
            if (string.IsNullOrWhiteSpace(userIp))
                return new GeoLocationResponse(); // return default if IP is missing

            string cacheKey = $"UserLocation_{userIp}";

            if (_cache.TryGetValue(cacheKey, out GeoLocationResponse cachedLocation))
            {
                return cachedLocation;
            }

            try
            {
                var response = await _httpClient.GetFromJsonAsync<GeoLocationResponse>($"{GeoApiUrl}{userIp}");
                var location = response ?? new GeoLocationResponse();

                _cache.Set(cacheKey, location, TimeSpan.FromMinutes(LocationCacheDurationMinutes));

                return location;
            }
            catch
            {
                return new GeoLocationResponse(); // fallback to default if API fails
            }
        }

        // ✅ Get and cache prayer times based on user location
        public async Task<PrayerTimesResponse> GetPrayerTimesAsync(string userIp)
        {
            var location = await GetUserLocationAsync(userIp);

            if (location.Lat == 0 && location.Lon == 0)
                return new PrayerTimesResponse(); // No valid location

            string cacheKey = $"PrayerTimes_{location.Lat}_{location.Lon}";

            if (_cache.TryGetValue(cacheKey, out PrayerTimesResponse cachedPrayerTimes))
            {
                return cachedPrayerTimes;
            }

            try
            {
                var response = await _httpClient.GetFromJsonAsync<PrayerTimesResponse>(
                    $"{PrayerApiUrl}?latitude={location.Lat}&longitude={location.Lon}"
                );

                var prayerTimes = response ?? new PrayerTimesResponse();

                // ✅ Format times to AM/PM
                if (prayerTimes.Data?.Timings != null)
                {
                    var formattedTimings = new Dictionary<string, string>();

                    foreach (var timing in prayerTimes.Data.Timings)
                    {
                        if (DateTime.TryParse(timing.Value, out DateTime time))
                        {
                            formattedTimings[timing.Key] = time.ToString("hh:mm tt"); // <-- AM/PM Format
                        }
                        else
                        {
                            formattedTimings[timing.Key] = timing.Value; // Keep original if parsing fails
                        }
                    }

                    prayerTimes.Data.Timings = formattedTimings;
                }

                // ✅ Store in cache for 24 hours
                _cache.Set(cacheKey, prayerTimes, TimeSpan.FromHours(CacheDurationHours));

                return prayerTimes;
            }
            catch
            {
                return new PrayerTimesResponse(); // fallback to empty if API fails
            }
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
            public Dictionary<string, string> Timings { get; set; } // Prayer Name -> Time
        }
    }
}
