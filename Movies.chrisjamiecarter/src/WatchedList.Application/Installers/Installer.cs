using Microsoft.Extensions.DependencyInjection;
using WatchedList.Application.Services;

namespace WatchedList.Application.Installers;

/// <summary>
/// Installs all dependencies for the application project.
/// </summary>
public static class Installer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWatchedListService, WatchedListService>();

        return services;
    }
}
