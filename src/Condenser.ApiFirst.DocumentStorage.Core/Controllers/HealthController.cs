using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Core.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult CheckHealth()
        {
            return Ok();
        }
    }
}
