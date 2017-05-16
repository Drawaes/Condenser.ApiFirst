using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Verb
    {
        public List<string> Tags { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string OperationId { get; set; }
        public List<string> Consumes { get; set; }
        public List<string> Produces { get; set; }
        public Parameter[] Parameters { get; set; }
    }
}
