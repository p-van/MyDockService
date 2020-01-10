using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MyDockService.Controllers
{
    [ApiController]
    [Route("api/information")]
    public class InformationController : ControllerBase
    {
        private readonly InstanceConfiguration _instanceConfiguration;

        public InformationController(IOptions<InstanceConfiguration> instanceConfiguration)
        {
            _instanceConfiguration = instanceConfiguration.Value;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetTime()
        {
            await Task.CompletedTask;
            var response = $"{DateTime.UtcNow.ToUniversalTime()} | Served :{_instanceConfiguration?.Id}";
            return Ok(response);
        }
    }

    [ApiController]
    [Route("health")]
    public class HealthCheckController : ControllerBase
    {
        private readonly InstanceConfiguration _instanceConfiguration;

        public HealthCheckController(IOptions<InstanceConfiguration> instanceConfiguration)
        {
            _instanceConfiguration = instanceConfiguration.Value;
        }
        
        [HttpGet]
        public async Task<ActionResult> Ping()
        {
            await Task.CompletedTask;
            var response = $"Served :{_instanceConfiguration?.Id}";
            return Ok(response);
        }
    }
}