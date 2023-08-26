using Movies.Data;

namespace Movies.Repositories;

public class UnitOfWork: IUnitOfWork
{
    public IMovieRepository Movies { get; set; }
    public ILikedMovieRepository LikedMovies { get; set; }

    private readonly MoviesContext _moviesContext;

    public UnitOfWork(MoviesContext moviesContext)
    {
        _moviesContext = moviesContext;
        Movies = new MovieRepository(moviesContext);
        LikedMovies = new LikedMovieRepository(moviesContext);
    }
    
    public async Task<int> SaveChanges()
    {
        return await _moviesContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _moviesContext.Dispose();
    }
}