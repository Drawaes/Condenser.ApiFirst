using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using CondenserDotNet.Client;
using System;

namespace CondenserDotNet.Environment.LightUp
{
    public class ProAzureAppServicesHostingStartup : IHostingStartup
    {
        internal class Program { public static void Main() { } }

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(collection =>
            {
                collection.AddConsulServices();
            });
            builder.UseStartup<Startup>();
        }

        internal class Startup
        {
            public void Configure(IApplicationBuilder app, IServiceManager serviceManager)
            {
                serviceManager
                .AddHttpHealthCheck("api/health", 30)
                .WithDeregisterIfCriticalAfterMinutes(2)
                .RegisterServiceAsync();
            }
        }

    }
}
