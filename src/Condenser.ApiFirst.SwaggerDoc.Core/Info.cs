using System;
using System.Collections.Generic;
using System.Text;

namespace Condenser.ApiFirst.SwaggerDoc.Core
{
    public class Info
    {
        public string Description { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string TermsOfService { get; set; }
        public Contact Contact { get; set; }
        public License License { get; set; }
    }
}
