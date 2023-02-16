using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class MovieData
{
    [JsonPropertyName("movies")]
    public List<MovieDto>? MoviesDto { get; set; }
}
