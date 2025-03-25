using EdufyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetPrayerTimes()
        {
            try
            {
                _logger.LogInformation("Fetching prayer times...");
                var result = await _prayerTimesService.GetPrayerTimes();

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

        [HttpGet("location")]
        public async Task<IActionResult> GetUserLocation()
        {
            try
            {
                _logger.LogInformation("Fetching user location...");
                var location = await _prayerTimesService.GetUserLocation();

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
                    Country = location.Country,
                    City = location.City
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching user location.");
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }
    }
}
