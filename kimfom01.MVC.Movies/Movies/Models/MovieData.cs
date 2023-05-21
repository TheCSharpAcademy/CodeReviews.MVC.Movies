using System.Text.Json.Serialization;

namespace Movies.Models;

public class MovieData
{
    [JsonPropertyName("movies")]
    public IEnumerable<MovieApiDto>? MoviesDto { get; set; }
}