using Newtonsoft.Json;
using System;

namespace Condenser.ApiFirst.ServiceDiscoveryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = System.IO.File.ReadAllText("petstore.json");
            var registry = new CondenserDotNet.Client.Services.ServiceRegistry();

            var client = new DocumentStorage.Api.ApiClient(registry);
            var key = ' ';
            while (key != 'x')
            {
                var swagger = JsonConvert.DeserializeObject<DocumentStorage.Api.Models.Schema>(doc);
                var result = client.SaveNewSwaggerDocWithHttpMessagesAsync("TestAgent", "ServiceName", "ServiceId", swagger);
                Console.WriteLine("Waiting");
                result.Wait();
                Console.WriteLine($"Result Code {result.Result.Response.StatusCode}");
                if (result.Result.Response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Response was {result.Result.Response.Content.ReadAsStringAsync().Result}");
                }
                key = Console.ReadKey().KeyChar;
            }
        }
    }
}