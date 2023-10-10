namespace MVC.TVShows.Forser.Models
{
    public class TVShow_Genre
    {
        public int Id { get; set; }
        public int TVShow_Id { get; set; }
        public TVShow TVShow { get; set; }
        public int Genre_Id { get; set; }
        public Genre Genre { get; set; }
    }
}