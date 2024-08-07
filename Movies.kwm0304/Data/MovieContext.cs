using Microsoft.EntityFrameworkCore;
using Movies.kwm0304.Models;

namespace Movies.kwm0304.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = default!;
    }
}
