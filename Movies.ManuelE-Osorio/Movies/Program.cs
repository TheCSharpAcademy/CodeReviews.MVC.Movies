using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext") ?? throw new InvalidOperationException("Connection string 'MovieContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRequestLocalization( new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture("en-US")
    }
);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.InitializeMovies(services);
    SeedData.InitializeTvShows(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
