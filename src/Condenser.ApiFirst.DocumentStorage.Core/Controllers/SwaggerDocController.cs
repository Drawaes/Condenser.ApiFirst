using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Condenser.ApiFirst.DocumentStorage.Core.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerDocController:ControllerBase
    {
        [HttpPost("{agent}/{serviceName}/{serviceId}")]
        [SwaggerOperation("SaveNewSwaggerDoc")]
        [ProducesResponseType(typeof(string), 200)]
        public Task<ActionResult> Post(string agent, string serviceName, string serviceId, [FromBody] SwaggerDoc.Core.Schema swaggerDoc)
        {
            return Task.Delay(60000).ContinueWith(t => (ActionResult)Ok());
        }
    }
}
