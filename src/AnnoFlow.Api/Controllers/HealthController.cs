using Microsoft.AspNetCore.Mvc;

namespace AnnoFlow.Api.Controllers
{
    public class HealthController : ApiController
    {
        public HealthController(ILogger<HealthController> targetLogger)
            : base(targetLogger)
        {
        }

        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok();
        }
    }
}