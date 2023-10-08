namespace MVC.TVShows.Forser.Models
{
    public class TVShow_Rating
    {
        public int Id { get; set; }
        public TVShow? TVShow { get; set; }
        public int? TVShow_Id { get; set; }
        public Rating? Rating { get; set; }
        public int? Rating_Id { get; set; }
    }
}