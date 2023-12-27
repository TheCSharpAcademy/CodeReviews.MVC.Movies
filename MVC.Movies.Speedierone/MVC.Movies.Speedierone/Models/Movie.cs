using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Movies.Speedierone.Models
{
    public class Movie
    {
        public int Id {  get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
