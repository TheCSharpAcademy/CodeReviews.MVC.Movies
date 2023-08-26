using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Repositories;

public class LikedMovieRepository: Repository<LikedMovie>, ILikedMovieRepository
{
    public LikedMovieRepository(MoviesContext movieDbContext) : base(movieDbContext)
    {
    }

    public bool CheckMovie(int? movieId, string? userId)
    {
        return DbSet.Any(mov => mov.MovieId == movieId && mov.UserId == userId);
    }

    public IEnumerable<LikedMovie> GetLikedMovies(string userId)
    {
        var movies = DbSet
            .Where(mov => mov.UserId == userId)
            .AsNoTracking();

        return movies;
    }
}