using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace postconfigureservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITestCache _testCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestCache testCache)
        {
            _logger = logger;
            _testCache = testCache;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _testCache.GetItems().ToArray();
        }
    }
}
