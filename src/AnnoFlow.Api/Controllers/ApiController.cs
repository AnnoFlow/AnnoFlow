using Microsoft.AspNetCore.Mvc;

namespace AnnoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ILogger logger;

        protected ApiController(ILogger targetLogger)
        {
            logger = targetLogger;
        }
    }
}