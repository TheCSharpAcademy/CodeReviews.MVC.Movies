using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class DetailsRoot
{
    [JsonPropertyName("data")]
    public DetailsData? DetailsData { get; set; }
}
