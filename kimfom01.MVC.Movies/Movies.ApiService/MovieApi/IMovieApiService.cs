using Movies.ApiService.Models;

namespace Movies.ApiService.MovieApi;

public interface IMovieApiService
{
    Task<IEnumerable<MovieApiDto>?> FetchMovies(Filter? filter);
}
