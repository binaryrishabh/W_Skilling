var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

// Conventional Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurant}/{action=Menu}/{id?}");  // Changed Home to Restaurant

// Custom Route
app.MapControllerRoute(
    name: "foodOrder",
    pattern: "order-food",
    defaults: new { controller = "Restaurant", action = "Menu" });

app.Run();