using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cache
{

    public interface ITestCache 
    {
        IEnumerable<string> GetItems();
        Task BootstrapCache();
    }

    public class TestCache : ITestCache
    {
        private readonly List<string> _cache;
        
        public TestCache()
        {
            _cache = new List<string>();
        }

        public IEnumerable<string> GetItems()
        {
            Console.WriteLine("Getting stuff");
            foreach(var item in _cache){
                yield return item;
            }
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task BootstrapCache() 
        {
            Console.WriteLine("Bootstrapping Cache");
            await Task.Delay(2000);
            _cache.AddRange(Summaries);
        }

    }
}
