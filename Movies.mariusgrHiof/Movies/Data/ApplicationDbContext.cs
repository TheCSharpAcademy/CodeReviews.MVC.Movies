using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Rocky 4",
                Genre = "Drama",
                Year = 1985,
                DurationInMinutes = 90
            },
            new Movie
            {
                Id = 2,
                Title = "Rocky 3",
                Genre = "Drama",
                Year = 1983,
                DurationInMinutes = 77
            },
            new Movie
            {
                Id = 3,
                Title = "Rocky 2",
                Genre = "Drama",
                Year = 1979,
                DurationInMinutes = 95
            }
            );
    }
}

