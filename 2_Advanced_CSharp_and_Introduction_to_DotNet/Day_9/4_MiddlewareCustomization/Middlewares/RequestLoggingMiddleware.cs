using System.Diagnostics;

namespace _4_MiddlewareCustomization.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} from IP: {context.Connection.RemoteIpAddress}");
        
        await _next(context);
        
        stopwatch.Stop();
        _logger.LogInformation($"Response: {context.Response.StatusCode} took {stopwatch.ElapsedMilliseconds}ms");
    }
}