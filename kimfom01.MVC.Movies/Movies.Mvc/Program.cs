using Microsoft.EntityFrameworkCore;
using Movies.ApiService.MovieApi;
using Movies.DataAccessLibrary.Context;
using Movies.DataAccessLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDb"));
});
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMovieApiService, MovieApiService>();
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
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
