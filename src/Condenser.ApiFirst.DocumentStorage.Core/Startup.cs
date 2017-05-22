using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using CondenserDotNet.Client;
using CondenserDotNet.Middleware.ConsulCleanShutdown;
using System;
using Microsoft.AspNetCore.Hosting;
using CondenserDotNet.Configuration;
using CondenserDotNet.Configuration.Consul;
using Microsoft.Extensions.Configuration;
using Condenser.ApiFirst.DocumentStorage.Core.Models;
using Condenser.ApiFirst.DocumentStorage.Core.Data;
using Microsoft.Extensions.Logging;

namespace Condenser.ApiFirst.DocumentStorage.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var configRegistry = new ConsulRegistry(null);
            configRegistry.AddUpdatingPathAsync("myCompany/Condenser").Wait();
            Configuration = configRegistry;
        }

        public static IConfigurationRegistry Configuration;

        public void Configure(IApplicationBuilder app, IServiceManager serviceManager)
        {
            serviceManager
                .AddHttpHealthCheck("api/health", 1);
            serviceManager.WithDeregisterIfCriticalAfterMinutes(1);
            serviceManager.RegisterServiceAsync();

            app.UseConsulShutdown();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Document Storage");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.ConfigureReloadable<SwaggerProcessorConfig>(Configuration, "SwaggerProcessor");

            services.AddConsulServices();
            services.AddConsulShutdown();

            services.AddSingleton<DatabaseConnection>();
            services.AddSingleton<SwaggerDocRepository>();

            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddJsonOptions(j =>
                {
                    j.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Swagger Document Storage", Version = "v1", License = new License() { Name = "MIT" } });
                c.DescribeAllEnumsAsStrings();
            });
        }
    }
}
