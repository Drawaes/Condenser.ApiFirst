using CondenserDotNet.Client.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Condenser.ApiFirst.DocumentStorage.Core.Data
{
    public class DatabaseConnection
    {
        private IServiceRegistry _registry;

        public DatabaseConnection(IServiceRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public Task<string> GetConnectionString()
        {
            var password = Environment.GetEnvironmentVariable("SA_PASSWORD");
            return _registry.GetServiceInstanceAsync("sqlserver").ContinueWith(infoTask =>
            {
                var info = infoTask.Result;
                return $"Data Source={info.Address},{info.Port};User Id=sa;Password={password};Initial Catalog=CondenserApiFirst";
            });
        }
    }
}
