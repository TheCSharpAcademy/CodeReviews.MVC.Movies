using Movies.Data;
using Movies.Models;

namespace Movies.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(MoviesContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task AddEntities(IEnumerable<Movie> entities)
    {
        var oldMovies = base.GetEntities();

        await base.DeleteEntities(oldMovies);

        await base.AddEntities(entities);
    }
}