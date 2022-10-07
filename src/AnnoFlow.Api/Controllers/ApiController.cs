using Microsoft.AspNetCore.Mvc;

namespace AnnoFlow.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected ApiController(ILogger logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; }
    }
}