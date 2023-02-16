using System.Text.Json.Serialization;

namespace Movies.Models.APIModels;

public class DetailsDto
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("medium_cover_image")]
    public required string ImageUrl { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }

    [JsonPropertyName("genres")]
    public required List<string> Genres { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("description_full")]
    public required string Description { get; set; }

    public string Genre
    {
        get { return string.Join(" ", Genres); }
    }
}
