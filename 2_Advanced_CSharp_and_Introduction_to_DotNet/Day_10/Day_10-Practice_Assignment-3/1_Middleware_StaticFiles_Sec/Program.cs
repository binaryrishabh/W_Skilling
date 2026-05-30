using _1_Middleware_StaticFiles_Sec.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add middleware
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

// Static files with security headers
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Content-Security-Policy",
            "default-src 'self'; script-src 'self' 'unsafe-inline'");
        ctx.Context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    }
});

// Serve index.html
app.Run(async context =>
{
    if (context.Request.Path == "/") {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("wwwroot/index.html");
    }
});

app.Run();