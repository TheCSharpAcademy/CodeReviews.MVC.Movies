using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.TVShows.Forser.Models
{
    public class CreateShowModel
    {
        public TVShow tvShow { get; set; }
        [BindProperty]
        public List<SelectListItem> allGenres { get; set; }
    }
}