using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? TVShowId { get; set; }
        public TVShow? TVShow { get; set; }
    }
}