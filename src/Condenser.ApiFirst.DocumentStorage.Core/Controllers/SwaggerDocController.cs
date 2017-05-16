using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Core.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerDocController
    {
        [HttpPost("{agent}/{serviceName}/{serviceId}")]
        [SwaggerOperation("SaveNewSwaggerDoc")]
        public void Post(string agent, string serviceName, string serviceId, [FromBody] SwaggerDoc.Core.Schema swaggerDoc)
        {
            
        }
    }
}
