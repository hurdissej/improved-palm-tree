using System;
using System.Threading;
using System.Threading.Tasks;
using cache;
using Microsoft.Extensions.Hosting;

public class TestHostedService: IHostedService
{
    // We need to inject the IServiceProvider so we can create 
    // the scoped service, MyDbContext
    private readonly IServiceProvider _serviceProvider;
    public TestHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Bootstwappering da cache");
        var cache = (ITestCache) _serviceProvider.GetService(typeof(ITestCache));
        await cache.BootstrapCache();
        
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // noop
        return Task.CompletedTask;
    }
}