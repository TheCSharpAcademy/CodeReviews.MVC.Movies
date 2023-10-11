namespace MVC.TVShows.Forser.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShowGenre { get; set; } = string.Empty;
        public bool Checked { get; set; }
        public IEnumerable<TVShow_Genre> TVShow_Genres { get; set; }
    }
}