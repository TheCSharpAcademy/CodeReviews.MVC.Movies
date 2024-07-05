using Microsoft.AspNetCore.Mvc.Rendering;
using MovieManager.Genres.Models;

namespace MovieManager.Movies.Models
{
    public class MovieListViewModel
    {
        public List<Movie> Movies { get; set; }
        public int? SelectedGenreId { get; set; }
        public Genre? SelectedGenre { get; set; }
        public string? SearchText { get; set; }

        public List<Genre> Genres { get; set; }
        public SelectList GenresSelectList { get; set; }
    }
}
