using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Property
    {
        [Newtonsoft.Json.JsonProperty(propertyName:"$ref")]
        public string Ref { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
    }
}
