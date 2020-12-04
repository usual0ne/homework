using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middleware
{
    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLog(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
