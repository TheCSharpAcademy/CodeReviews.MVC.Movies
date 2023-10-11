using Microsoft.EntityFrameworkCore;
using MoviesMVCCarDioLogic.Data;
using MoviesMVCCarDioLogic.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesMVCCarDioLogicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesMVCCarDioLogicContext") ?? throw new InvalidOperationException("Connection string 'MoviesMVCCarDioLogicContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//for validation
app.UseRequestLocalization("pt-pt");

app.Run();
