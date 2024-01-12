using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Movies.K_MYR.Models;

public class MovieListViewModel
{
    public List<Movie> Movies { get; set; } = [];
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
    public Movie NewMovie { get; set; } = new Movie();
}
    
