using _4_MiddlewareCustomization.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Custom middlewares
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<NameCheckMiddleware>();

app.UseAuthorization();
app.MapRazorPages();

app.Run();