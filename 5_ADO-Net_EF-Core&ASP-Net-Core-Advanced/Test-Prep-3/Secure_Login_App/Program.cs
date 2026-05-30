using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Secure_Login_App.Data;
using Secure_Login_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure Database (In-Memory for simplicity)
builder.Services.AddDbContext<Application_Db_Context>(options =>
    options.UseInMemoryDatabase("SecureLoginDB"));

// Configure Identity
builder.Services.AddIdentity<Application_User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<Application_Db_Context>()
.AddDefaultTokenProviders();

// Configure Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Access_Denied";
    options.SlidingExpiration = true;
});

// Enforce HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7117;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Custom HTTPS redirection with correct port
app.Use(async (context, next) =>
{
    if (!context.Request.IsHttps) {
        var host = context.Request.Host.Host;
        var httpsUrl = $"https://{host}:7117{context.Request.Path}{context.Request.QueryString}";
        context.Response.Redirect(httpsUrl, permanent: true);
        return;
    }
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed roles and users
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}

app.Run();