using Data.Models;

namespace Services;

public interface IMoviesService
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie?> GetMovieById(int id);
    Task AddMovie(Movie movie);
    Task UpdateMovie(Movie movie);
    Task DeleteMovie(Movie movie);
}