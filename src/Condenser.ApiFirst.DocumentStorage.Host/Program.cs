using Condenser.ApiFirst.DocumentStorage.Core;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Condenser.ApiFirst.DocumentStorage.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = CondenserDotNet.Client.ServiceManagerConfig.GetNextAvailablePort();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls($"http://*:{port}")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}