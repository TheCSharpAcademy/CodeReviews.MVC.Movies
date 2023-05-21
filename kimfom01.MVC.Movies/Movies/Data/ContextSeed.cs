using Microsoft.AspNetCore.Identity;
using Movies.Models;

namespace Movies.Data;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        try
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogError(ex, "Error occured while creating the roles");
        }
    }

    public static async Task CreateAdminAsync(IServiceProvider serviceProvider)
    {
        var admin = new ApplicationUser
        {
            FirstName = "Super",
            LastName = "Admin",
            UserName = "superadmin",
            Email = "superadmin@movies.com"
        };

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (userManager.Users.All(user => user.Id != admin.Id))
        {
            var user = await userManager.FindByEmailAsync(admin.Email);

            if (user is null)
            {
                await userManager.CreateAsync(admin, "adminPa$$word123");
                await userManager.SetUserNameAsync(admin, admin.Email);
                await userManager.AddToRolesAsync(admin, new[] { Roles.Admin.ToString(), Roles.Basic.ToString() });
            }
        }
    }
}