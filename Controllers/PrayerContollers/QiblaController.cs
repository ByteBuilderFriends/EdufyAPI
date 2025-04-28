using EdufyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.PrayerControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QiblaController : ControllerBase
    {
        private readonly QiblaDirectionService _qiblaService;

        public QiblaController(QiblaDirectionService qiblaService)
        {
            _qiblaService = qiblaService;
        }

        // ✅ Get Qibla Direction
        [HttpGet("direction")]
        public async Task<IActionResult> GetQiblaDirection()
        {
            // 🧠 Get User IP Address
            var userIp = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                         ?? HttpContext.Connection.RemoteIpAddress?.ToString();

            if (string.IsNullOrWhiteSpace(userIp))
            {
                return BadRequest(new { message = "Unable to detect user IP address." });
            }

            // 📍 Pass user IP to the service
            var qiblaDirection = await _qiblaService.GetQiblaCompassAsync(userIp);

            if (qiblaDirection == null)
            {
                return NotFound(new { message = "Could not determine Qibla direction." });
            }

            return Ok(qiblaDirection);
        }


    }
}
