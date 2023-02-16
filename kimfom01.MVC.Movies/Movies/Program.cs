using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Repositories;
using Movies.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDb"));
});
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMovieAPIService, MovieAPIService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

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
