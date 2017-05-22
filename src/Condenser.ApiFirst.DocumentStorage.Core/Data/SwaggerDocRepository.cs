using Condenser.ApiFirst.DocumentStorage.Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Condenser.ApiFirst.DocumentStorage.Core.Data
{
    public class SwaggerDocRepository
    {
        private static readonly string _insertQuery = "Insert into SwaggerDoc (AgentId, ServiceId, ServiceName, SwaggerDoc, DateSaved) "
            + $"VALUES (@{nameof(SwaggerDocument.AgentId)},@{nameof(SwaggerDocument.ServiceId)}, @{nameof(SwaggerDocument.ServiceName)}, @{nameof(SwaggerDocument.SwaggerDoc)}, @{nameof(SwaggerDocument.DateSaved)})"
            + $";SELECT CAST(SCOPE_IDENTITY() as int)";
        private DatabaseConnection _connection;    
        
        public SwaggerDocRepository(DatabaseConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public async Task<int> AddSwaggerDoc(string serviceId, string agentId, string serviceName, string swaggerDoc)
        {
            var record = new SwaggerDocument()
            {
                ServiceId = serviceId ?? throw new ArgumentNullException(nameof(serviceId)),
                ServiceName = serviceName ?? throw new ArgumentNullException(nameof(serviceName)),
                SwaggerDoc = swaggerDoc ?? throw new ArgumentNullException(nameof(swaggerDoc)),
                AgentId = agentId ?? throw new ArgumentNullException(nameof(agentId)),
                DateSaved = DateTime.UtcNow
            };
            
            using (var conn = new SqlConnection(await _connection.GetConnectionString()))
            {
                await conn.OpenAsync();
                return await conn.ExecuteScalarAsync<int>(_insertQuery, record);
            }
        }
    }
}
