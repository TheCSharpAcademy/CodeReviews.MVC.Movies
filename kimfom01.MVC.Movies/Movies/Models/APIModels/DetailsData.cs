using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class DetailsData
{
    [JsonPropertyName("movie")]
    public DetailsDto? MoviesDetail { get; set; }
}
