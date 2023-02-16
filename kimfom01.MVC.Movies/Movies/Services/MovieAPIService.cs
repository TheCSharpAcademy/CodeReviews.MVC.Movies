using Movies.Models;
using Movies.Models.APIModels;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Movies.Services;

public class MovieAPIService : IMovieAPIService
{
    private readonly HttpClient _httpClient;

    public MovieAPIService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.BaseAddress = new Uri(config.GetSection("BaseAddress").Value
            ?? throw new NullReferenceException("Base address is missing from configuration (appsettings.json)"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<DetailsDto?> FetchDetails(int? id)
    {
        using var response = await _httpClient.GetAsync($"movie_details.json?movie_id={id}");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();

            var detailsRoot = await JsonSerializer.DeserializeAsync<DetailsRoot>(stream);

            if (detailsRoot is null)
            {
                return null;
            }

            var data = detailsRoot.DetailsData;

            if (data is null)
            {
                return null;
            }

            var movieDetails = data.MoviesDetail;

            return movieDetails;
        }

        return null;
    }

    public async Task<IEnumerable<MovieDto>?> FetchMovies(Filter? filter)
    {
        using var response = await _httpClient.GetAsync($"list_movies.json?minimum_rating={filter?.Rating}&limit=50");

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();

            var movieRoot = await JsonSerializer.DeserializeAsync<MovieRoot>(stream);

            if (movieRoot is null)
            {
                return null;
            }

            var data = movieRoot.MovieData;

            if (data is null)
            {
                return null;
            }

            var movieList = data.MoviesDto;

            return movieList;
        }

        return null;
    }
}
