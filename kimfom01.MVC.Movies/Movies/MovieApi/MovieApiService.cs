using System.Net.Http.Headers;
using System.Text.Json;
using Movies.Models;

namespace Movies.MovieApi;

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _httpClient;

    public MovieApiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.BaseAddress = new Uri(config.GetSection("BaseAddress").Value
            ?? throw new NullReferenceException("Base address is missing from configuration (appsettings.json)"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IEnumerable<MovieApiDto>?> FetchMovies(Filter? filter)
    {
        using var response = await _httpClient.GetAsync($"list_movies.json?minimum_rating={filter?.Rating}&limit=50");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var stream = await response.Content.ReadAsStreamAsync();

        var movieRoot = await JsonSerializer.DeserializeAsync<MovieRoot>(stream);

        var data = movieRoot?.MovieData;

        var movieList = data?.MoviesDto;

        return movieList;
    }
}
