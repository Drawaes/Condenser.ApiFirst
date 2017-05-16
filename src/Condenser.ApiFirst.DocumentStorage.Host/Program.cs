using Condenser.ApiFirst.DocumentStorage.Core;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Condenser.ApiFirst.DocumentStorage.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:8888")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}