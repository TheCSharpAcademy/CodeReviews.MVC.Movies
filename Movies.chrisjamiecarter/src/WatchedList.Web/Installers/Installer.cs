namespace WatchedList.Web.Installers;

/// <summary>
/// Installs all dependencies for the web application project.
/// </summary>
public static class Installer
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        return services;
    }
}
