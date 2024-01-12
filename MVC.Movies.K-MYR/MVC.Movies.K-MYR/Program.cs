using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Data;
using MVC.Movies.K_MYR.Models;
using System.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var systemCulture = CultureInfo.CurrentCulture;
CultureInfo.DefaultThreadCurrentCulture = systemCulture;
CultureInfo.DefaultThreadCurrentUICulture = systemCulture;  

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
