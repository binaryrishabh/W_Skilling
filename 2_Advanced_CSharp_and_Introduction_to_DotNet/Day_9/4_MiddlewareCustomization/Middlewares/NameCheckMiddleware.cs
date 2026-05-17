namespace _4_MiddlewareCustomization.Middlewares;

public class NameCheckMiddleware
{
    private readonly RequestDelegate _next;

    public NameCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/privacy" && context.Request.Method == "GET")
        {
            var name = context.Request.Query["name"].ToString();
            if (!string.IsNullOrEmpty(name) && name == "Rishabh")
            {
                await context.Response.WriteAsync($"<h1>Welcome Raj! Special access granted.</h1>");
                return;
            }
        }
        await _next(context);
    }
}