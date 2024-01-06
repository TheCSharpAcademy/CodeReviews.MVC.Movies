using Microsoft.EntityFrameworkCore;

namespace MVC.Movies.K_MYR.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) {}    
    public DbSet<MVC.Movies.K_MYR.Models.Movie> Movies { get; set; }

}
