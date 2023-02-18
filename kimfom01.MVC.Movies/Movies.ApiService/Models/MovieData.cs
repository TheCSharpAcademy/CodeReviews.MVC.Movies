using System.Text.Json.Serialization;

namespace Movies.ApiService.Models;

public class MovieData
{
    [JsonPropertyName("movies")]
    public IEnumerable<MovieApiDto>? MoviesDto { get; set; }
}