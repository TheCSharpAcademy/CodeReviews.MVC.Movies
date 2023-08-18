using kmakai.MVC.Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace kmakai.MVC.Movies.DataAccess;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Book> Books { get; set; }
}
