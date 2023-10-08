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
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public bool BeenWatched { get; set; } = false;
    }
}