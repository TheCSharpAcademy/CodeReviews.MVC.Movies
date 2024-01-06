using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVC.Movies.K_MYR.Models;

public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
}
    
