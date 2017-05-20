using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using CondenserDotNet.Client;
using CondenserDotNet.Middleware.ConsulCleanShutdown;
using System;

namespace Condenser.ApiFirst.DocumentStorage.Core
{
    public class Startup
    {
        public static int Port { get; set; }

        public void Configure(IApplicationBuilder app, IServiceManager serviceManager)
        {
            serviceManager
                .AddHttpHealthCheck("api/health", 30);
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
            services.AddConsulServices();
            services.AddConsulShutdown();

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
            services.Configure<ServiceManagerConfig>( conf =>
            {
                conf.ServiceId = $"OurInstance{Port}";
            });
        }
    }
}
