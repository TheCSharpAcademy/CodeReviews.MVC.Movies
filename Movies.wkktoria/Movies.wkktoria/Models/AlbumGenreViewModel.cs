using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movies.wkktoria.Models;

public class AlbumGenreViewModel
{
    public List<Album>? Albums { get; set; }

    public SelectList? Genres { get; set; }

    public string? AlbumGenre { get; set; }

    public string? SearchString { get; set; }
}