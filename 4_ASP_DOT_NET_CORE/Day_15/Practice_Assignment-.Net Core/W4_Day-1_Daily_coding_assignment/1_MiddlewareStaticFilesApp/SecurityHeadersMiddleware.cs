public class SecurityHeadersMiddleware {
    private readonly RequestDelegate _next;

    public SecurityHeadersMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        // Only add CSP for production, skip during debugging
        if (!context.Request.Headers.ContainsKey("Debug")) {
            context.Response.Headers.Add("Content-Security-Policy",
                "default-src 'self'; script-src 'self' 'unsafe-inline' 'unsafe-eval'; connect-src 'self' ws://localhost:* http://localhost:*");
        }
        await _next(context);
    }
}