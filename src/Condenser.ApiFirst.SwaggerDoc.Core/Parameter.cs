using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Parameter
    {
        public string In { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }

    }
}
