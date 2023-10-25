namespace MVC.TVShows.Forser.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Certification { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsSelected { get; set; }
        public TVShow_Rating? TVShow_Rating { get; set; }
    }
}