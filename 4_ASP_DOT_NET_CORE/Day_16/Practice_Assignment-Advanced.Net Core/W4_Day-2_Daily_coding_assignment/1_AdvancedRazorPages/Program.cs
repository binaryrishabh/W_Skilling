var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

// Custom route for product details
app.MapControllerRoute("productRoute", "Products/{id}",
    new { controller = "Home", action = "Index" });

app.MapRazorPages();
app.Run();