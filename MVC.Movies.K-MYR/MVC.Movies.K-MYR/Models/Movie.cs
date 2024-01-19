using System.ComponentModel.DataAnnotations;

namespace MVC.Movies.K_MYR.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }
    [Required]
    [Display(Name="Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    public string? Genre { get; set; }    
    [DataType(DataType.Currency)]      
    [Range(1,999)]
    public decimal Price { get; set; }
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    public string? Rating { get; set; }
}
