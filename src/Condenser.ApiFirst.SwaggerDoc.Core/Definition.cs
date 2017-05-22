using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Definition
    {
        public string Type { get; set; }
        public Dictionary<string, Property> Properties { get; set; }
    }
}
