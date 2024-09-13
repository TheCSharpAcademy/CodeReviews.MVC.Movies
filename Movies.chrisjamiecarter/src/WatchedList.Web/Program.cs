using Microsoft.EntityFrameworkCore;
using WatchedList.Application.Installers;
using WatchedList.Infrastructure.Installers;
using WatchedList.Web.Installers;

namespace WatchedList.Web;

/// <summary>
/// The entry point for the WatchedList web application. This class is responsible for configuring 
/// and launching the application, including setting up services, configuring the HTTP request 
/// pipeline, and seeding the database with initial data.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("WatchedListDataContext") ?? throw new InvalidOperationException("Connection string 'WatchedListDataContext' not found.");

        // Add Clean Architecture project services to the container.
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(connectionString);
        builder.Services.AddWeb();

        var app = builder.Build();

        // Seed the database.
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        services.SeedDatabase();

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

        app.Run();
    }
}
