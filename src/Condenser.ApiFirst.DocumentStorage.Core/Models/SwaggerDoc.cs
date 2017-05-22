using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Core.Models
{
    public class SwaggerDocument
    {
        public int SwaggerDocId { get; set; }
        public string ServiceId { get; set; }
        public string AgentId { get; set; }
        public string ServiceName { get; set; }
        public string SwaggerDoc { get; set; }
        public DateTime DateSaved { get; set; }
    }
}
