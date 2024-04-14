using Microsoft.EntityFrameworkCore;

namespace Movie.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public virtual DbSet<Models.Movie> Movies { get; set; } = default!;
}