using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Data.SeedData;
using MovieManager.Movies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieManagerContext") ?? throw new InvalidOperationException("Connection string 'MovieManagerContext' not found.")));
builder.Services.AddScoped<MovieRepository>();

builder.Services.AddSingleton<Seeder>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieManagerContext>();
    dbContext.Database.EnsureCreated();
}

app.Services.GetRequiredService<Seeder>().SeedIfNoMovies();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Movies/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();


