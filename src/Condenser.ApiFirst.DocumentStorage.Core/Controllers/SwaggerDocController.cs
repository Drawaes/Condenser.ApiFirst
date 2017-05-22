using Condenser.ApiFirst.DocumentStorage.Core.Data;
using Condenser.ApiFirst.DocumentStorage.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Condenser.ApiFirst.DocumentStorage.Core.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerDocController : ControllerBase
    {
        private SwaggerDocRepository _repo;
        private IOptions<SwaggerProcessorConfig> _config;
        private SwaggerProcessorConfig _frozen;

        public SwaggerDocController(SwaggerDocRepository repo, IOptions<SwaggerProcessorConfig> swaggerConfig)
        {
            _config = swaggerConfig;
            _repo = repo;
            _frozen = _config.Value;
        }

        [HttpPost("{agent}/{serviceName}/{serviceId}")]
        [SwaggerOperation("SaveNewSwaggerDoc")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<ActionResult> Post(string agent, string serviceName, string serviceId, [FromBody] SwaggerDoc.Core.Schema swaggerDoc)
        {
            if(_config.Value.DelayForProcessing != _frozen.DelayForProcessing)
            {
                throw new InvalidOperationException();
            }
            var configValues = _config.Value;
            var result = await _repo.AddSwaggerDoc(serviceId, agent, serviceName, JsonConvert.SerializeObject(swaggerDoc));
            await Task.Delay(configValues.DelayForProcessing);
            return Ok(configValues.DelayForProcessing);
        }
    }
}
