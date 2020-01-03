using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cache;
using Microsoft.AspNetCore.Http;

namespace middleware
{
    public class BootstrapCacheMiddleware
    {
        private readonly RequestDelegate _next;
        public BootstrapCacheMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITestCache cache)
        {
            await cache.BootstrapCache();
            await _next(httpContext);
        }
    }
}
