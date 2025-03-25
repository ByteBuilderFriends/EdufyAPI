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
            var qiblaDirection = await _qiblaService.GetQiblaCompass();

            if (qiblaDirection == null)
                return NotFound(new { message = "Could not determine Qibla direction." });

            return Ok(qiblaDirection);
        }

    }
}
