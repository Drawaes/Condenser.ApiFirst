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
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .Build();

            host.Run();
        }
    }
}