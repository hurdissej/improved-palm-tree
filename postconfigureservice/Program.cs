using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cache;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace postconfigureservice
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var built = CreateHostBuilder(args).Build();
            
            //We can encapsulate this into an extension method in Finbourne.WebApi so we don't have to copy this code
            // it would be a breaking change though as we'd need to make that method async and the Main()
            var cache = (ITestCache) built.Services.GetService(typeof(ITestCache));
            await cache.BootstrapCache();

            built.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
