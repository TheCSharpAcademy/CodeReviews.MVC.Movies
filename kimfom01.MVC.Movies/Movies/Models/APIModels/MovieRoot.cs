using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class MovieRoot
{
    [JsonPropertyName("data")]
    public MovieData? MovieData { get; set; }
}
