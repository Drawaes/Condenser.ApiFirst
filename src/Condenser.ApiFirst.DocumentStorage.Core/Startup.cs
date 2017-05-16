using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Condenser.ApiFirst.DocumentStorage.Core
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Document Storage");
            });
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
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
            });
        }
    }
}
