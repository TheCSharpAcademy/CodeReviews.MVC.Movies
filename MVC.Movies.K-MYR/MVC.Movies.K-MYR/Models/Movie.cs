using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Movies.K_MYR.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }
    [Display(Name="Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [Range(1,100)]
    public decimal Price { get; set; }
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [Required]
    [StringLength(5)]
    public string? Rating { get; set; }

}
