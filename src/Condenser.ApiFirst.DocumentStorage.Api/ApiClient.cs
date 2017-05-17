using CondenserDotNet.Client.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Condenser.ApiFirst.DocumentStorage.Api
{
    public class ApiClient:SwaggerDocumentStorage
    {
        public ApiClient(IServiceRegistry registry)
            :base(registry.GetHttpHandler())
        {
            var ns = typeof(ApiClient).Namespace;
            var lastIndex = ns.LastIndexOf('.');
            ns = ns.Substring(0, lastIndex);
            BaseUri = new Uri($"http://{ns}");
        }
    }
}
