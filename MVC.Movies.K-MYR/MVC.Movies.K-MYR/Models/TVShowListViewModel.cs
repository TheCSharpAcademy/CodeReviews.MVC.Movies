using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Movies.K_MYR.Models
{
    public class TVShowListViewModel
    {
        public List<TVShow> TVShows { get; set; } = [];
        public SelectList? Genres { get; set; }
        public SelectList? Ratings { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string? ShowGenre { get; set; }
        public string? ShowRating { get; set; }
        public string? SearchString { get; set; }
        public string? YearRange { get; set; }
        public string? PriceRange { get; set; }
        public TVShow TVShow { get; set; } = new TVShow();
    }
}
