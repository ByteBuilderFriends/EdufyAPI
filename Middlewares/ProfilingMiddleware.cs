using System.Diagnostics;

namespace AskAMuslimAPI.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;

        public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation($"Request {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
