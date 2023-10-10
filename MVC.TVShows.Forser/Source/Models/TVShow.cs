using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.TVShows.Forser.Models
{
    public class TVShow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string Title { get; set; }
        public DateTime ShowStarted {  get; set; }
        public DateTime ShowCompleted { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public IEnumerable<TVShow_Rating> Ratings { get; set; }
        public IEnumerable<TVShow_Genre> Genres { get; set; }
        public bool BeenWatched { get; set; } = false;
    }
}