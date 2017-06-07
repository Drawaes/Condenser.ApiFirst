using Microsoft.AspNetCore.Hosting;
using Serilog;
using System;
using Microsoft.Extensions.DependencyInjection;
using CondenserDotNet.Client;
using CondenserDotNet.Middleware.ConsulCleanShutdown;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;

[assembly:HostingStartup(typeof(Condenser.ApiFirst.BootStrapper.HostingBootStrap))]

namespace Condenser.ApiFirst.BootStrapper
{
    public class HostingBootStrap : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            var applicationName = builder.GetSetting(WebHostDefaults.ApplicationKey);
            builder
                .UseUrls($"http://*:{ServiceManagerConfig.GetNextAvailablePort()}")
                .UseKestrel()
                .ConfigureLogging(loggerFactory =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.ColoredConsole(outputTemplate: "{Timestamp:yyyy-MMM-dd HH:mm:ss} [{Level}] [{scope}] {Message}{NewLine}{Exception}")
                        .CreateLogger();
                    loggerFactory.AddSerilog();
                })
                .ConfigureServices(s => ConfigureServices(s, applicationName));
        }

        private void ConfigureServices(IServiceCollection services, string applicationName)
        {
            services
                .AddTransient<IStartupFilter, HostingStartupFilter>()
                .AddConsulServices()
                .AddConsulShutdown()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = applicationName, Version = "v1" });
                    c.DescribeAllEnumsAsStrings();
                });
        }

        public class HostingStartupFilter : IStartupFilter
        {
            private IServiceManager _serviceManager;
            private string _applicationName;

            public HostingStartupFilter(IServiceManager serviceManager, IHostingEnvironment hostingEnvironment)
            {
                _serviceManager = serviceManager;
                _applicationName = hostingEnvironment.ApplicationName;
            }

            public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
            {
                return app =>
                {
                    _serviceManager
                        .AddHttpHealthCheck("api/health", 60)
                        .WithDeregisterIfCriticalAfterMinutes(1)
                        .RegisterServiceAsync();

                    app.UseConsulShutdown();

                    next(app);

                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", _applicationName);
                    });
                };
            }
        }
    }
}
