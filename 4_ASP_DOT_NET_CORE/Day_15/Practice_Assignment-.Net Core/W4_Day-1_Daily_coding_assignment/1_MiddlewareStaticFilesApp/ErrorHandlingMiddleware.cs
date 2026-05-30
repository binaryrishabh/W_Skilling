public class ErrorHandlingMiddleware {
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        }
        catch {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("<h1>Custom Error Page</h1><p>Something went wrong. Contact Ramesh.</p>");
        }
    }
}