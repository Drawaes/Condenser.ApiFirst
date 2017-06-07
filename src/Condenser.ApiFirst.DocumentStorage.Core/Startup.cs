using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Condenser.ApiFirst.DocumentStorage.Core
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}
