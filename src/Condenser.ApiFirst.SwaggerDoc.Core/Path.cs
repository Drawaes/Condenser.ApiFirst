using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Path
    {
        public Verb Post { get; set; }
        public Verb Put { get; set; }
        public Verb Get { get; set; }
        public Verb Delete { get; set; }
    }
}
