using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie { get; set; } = default!;
    public DbSet<TvShow> TvShow { get; set; } = default!;
}

