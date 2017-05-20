using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Core.Models
{
    public class SwaggerServiceDocument
    {
        public byte[] ServiceHash { get; set; }
        public string ServiceId { get; set; }
        public string AgentId { get; set; }
        public string ServiceName { get; set; }
        public string SwaggerDoc { get; set; }
    }
}
