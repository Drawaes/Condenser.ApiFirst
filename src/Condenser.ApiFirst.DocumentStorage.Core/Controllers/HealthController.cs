using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Core.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private ILogger _logger;

        public HealthController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<HealthController>();
        }

        [HttpGet]
        public ActionResult CheckHealth()
        {
            using (var scope = _logger.BeginScope("FirstScope"))
            {
                SomeOtherMethod();
            }
            _logger.LogWarning("Outside scopes");
            return Ok();
        }

        private void SomeOtherMethod()
        {
            using (var scope = _logger.BeginScope("SecondScope"))
            {
                _logger.LogError("In the method");
            }
        }
    }
}
