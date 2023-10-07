using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesMVCCarDioLogic.Models
{
    public class SerieGenreViewModel
    {
        public List<Serie>? Series { get; set; }
        public SelectList? Genres { get; set; }
        public string? SerieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
