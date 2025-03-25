using EdufyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.PrayerContollers
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

        [HttpGet("direction")]
        public async Task<IActionResult> GetQiblaDirection()
        {
            var qiblaDirection = await _qiblaService.GetQiblaDirection();

            if (qiblaDirection == null)
                return NotFound(new { message = "Could not determine Qibla direction." });

            return Ok(qiblaDirection);
        }
    }
}
