using EdufyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.ServiceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrayerTimesController : ControllerBase
    {
        private readonly PrayerTimesService _prayerTimesService;
        private readonly ILogger<PrayerTimesController> _logger;

        public PrayerTimesController(PrayerTimesService prayerTimesService, ILogger<PrayerTimesController> logger)
        {
            _prayerTimesService = prayerTimesService;
            _logger = logger;
        }

        // ✅ Get Prayer Times
        [HttpGet]
        public async Task<IActionResult> GetPrayerTimes()
        {
            try
            {
                var userIp = GetUserIpAddress();
                if (string.IsNullOrWhiteSpace(userIp))
                {
                    _logger.LogWarning("User IP address not found.");
                    return BadRequest(new { message = "User IP address could not be determined." });
                }

                _logger.LogInformation("Fetching prayer times for IP: {UserIp}", userIp);

                var result = await _prayerTimesService.GetPrayerTimesAsync(userIp);

                if (result == null)
                {
                    _logger.LogError("Failed to fetch prayer times.");
                    return StatusCode(500, new { message = "Failed to fetch prayer times." });
                }

                _logger.LogInformation("Prayer times retrieved successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching prayer times.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        // ✅ Get User Location
        [HttpGet("location")]
        public async Task<IActionResult> GetUserLocation()
        {
            try
            {
                var userIp = GetUserIpAddress();
                if (string.IsNullOrWhiteSpace(userIp))
                {
                    _logger.LogWarning("User IP address not found.");
                    return BadRequest(new { message = "User IP address could not be determined." });
                }

                _logger.LogInformation("Fetching user location for IP: {UserIp}", userIp);

                var location = await _prayerTimesService.GetUserLocationAsync(userIp);

                if (location == null || location.Lat == 0 || location.Lon == 0)
                {
                    _logger.LogWarning("Failed to fetch user location.");
                    return BadRequest(new { message = "Failed to fetch user location." });
                }

                _logger.LogInformation("User location retrieved successfully.");
                return Ok(new
                {
                    Latitude = location.Lat,
                    Longitude = location.Lon,
                    location.Country,
                    location.City
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching user location.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

        // ✅ Helper method to get User IP
        private string? GetUserIpAddress()
        {
            return Request.Headers["X-Forwarded-For"].FirstOrDefault()
                   ?? HttpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}
