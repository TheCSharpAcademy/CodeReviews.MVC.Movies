using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data;

public class MoviesContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<LikedMovie> LikedMovies { get; set; }
    
    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
