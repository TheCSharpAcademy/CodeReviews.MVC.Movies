using Microsoft.EntityFrameworkCore;
using MovieManager.Genres.Models;
using MovieManager.MovieActors.Models;
using MovieManager.MovieGenres.Models;
using MovieManager.Movies.Models;
using MovieManager.People.Models;

namespace MovieManager.Data
{
    public class MovieManagerContext : DbContext
    {
        public MovieManagerContext(DbContextOptions<MovieManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<MovieGenre> MovieGenre { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<MovieActor> MovieActor { get; set; } = default!;
    }
}
