using Movies.DataAccessLibrary.Context;
using Movies.DataAccessLibrary.Models;

namespace Movies.DataAccessLibrary.Repositories;

public class MovieRepository : Repository<MovieDbDto>, IMovieRepository
{
    public MovieRepository(MovieDbContext movieDbContext) : base(movieDbContext)
    {
    }

    public override async Task AddEntities(IEnumerable<MovieDbDto> entities)
    {
        var oldMovies = base.GetEntities();

        await base.DeleteEntities(oldMovies);

        await base.AddEntities(entities);
    }
}