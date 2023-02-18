using System.Text.Json.Serialization;

namespace Movies.ApiService.Models;

public class MovieRoot
{
    [JsonPropertyName("data")]
    public MovieData? MovieData { get; set; }
}
