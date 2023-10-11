using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string? Artist { get; set; }
        [Display(Name ="Album Name")]
        public string? AlbumName { get; set; }
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        [Column(TypeName = "decimal(18,2)"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
