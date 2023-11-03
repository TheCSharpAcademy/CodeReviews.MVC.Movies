using System.ComponentModel.DataAnnotations;

namespace Movies.wkktoria.Models;

public class Album
{
    [Key] public long Id { get; set; }

    [RegularExpression(@"(http)?s?:?(\/\/[^""']*\.(?:png|jpg|jpeg|gif|png|svg))")]
    [Display(Name = "Cover")]
    public string? CoverPath { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Artist { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string? Genre { get; set; }
}