using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieManager.Movies.Models
{
    public class MovieUpsertViewModel
    {
        public Movie Movie { get; set; }
        public List<int> GenreIds { get; set; } = new List<int>();
        public MultiSelectList? GenresSelectList { get; set; }
        public List<int>? ActorPersonIds { get; set; }
        public IEnumerable<SelectListItem>? ActorsSelectList { get; set; }
    }
}
