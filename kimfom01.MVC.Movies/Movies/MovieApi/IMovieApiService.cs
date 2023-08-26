using Movies.Models;

namespace Movies.MovieApi;

public interface IMovieApiService
{
    Task<IEnumerable<MovieApiDto>?> FetchMovies(Filter? filter);
}
