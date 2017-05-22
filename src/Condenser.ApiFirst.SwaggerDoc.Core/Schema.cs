using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Schema
    {
        public string Swagger { get; set; }
        public Info Info { get; set; }
        public string Host { get; set; }
        public string BasePath { get; set; }
        public Tag[] Tags { get; set; }
        public List<string> Schemes { get; set; }
        public Dictionary<string, Path> Paths { get; set; }
        public Dictionary<string, Definition> Definitions { get; set; }
    }
}
