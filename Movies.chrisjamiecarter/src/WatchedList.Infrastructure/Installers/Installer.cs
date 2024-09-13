using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WatchedList.Application.Repositories;
using WatchedList.Infrastructure.Contexts;
using WatchedList.Infrastructure.Repositories;
using WatchedList.Infrastructure.Services;

namespace WatchedList.Infrastructure.Installers;

/// <summary>
/// Installs all dependencies for the application project.
/// </summary>
public static class Installer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WatchedListDataContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IWatchedListRepository, WatchedListRepository>();

        return services;
    }

    public static IServiceProvider SeedDatabase(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<WatchedListDataContext>();
        context.Database.Migrate();

        var repository = serviceProvider.GetRequiredService<IWatchedListRepository>();
        SeederService.SeedDatabase(repository);

        return serviceProvider;
    }
}
