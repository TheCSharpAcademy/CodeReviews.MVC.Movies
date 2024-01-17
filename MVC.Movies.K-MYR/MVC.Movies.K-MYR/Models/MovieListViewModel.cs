using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Movies.K_MYR.Models;

public class MovieListViewModel
{
    public List<Movie> Movies { get; set; } = [];
    public SelectList? Genres { get; set; }
    public SelectList? Ratings { get; set; }    
    public int MinYear { get; set; }
    public int MaxYear { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public string? MovieGenre { get; set; }
    public string? MovieRating { get; set; }
    public string? SearchString { get; set; }    
    public string? YearRange { get; set; }
    public string? PriceRange { get; set; }
    public Movie Movie { get; set; } = new Movie();
}

