using MovieManager.MovieActors.Models;
using MovieManager.MovieGenres.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Movies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = "";

        [Required]
        public int Year { get; set; }

        [DataType(DataType.Url)]
        public string? Image { get; set; }
        public string? Color { get; set; }

        [Range(1, 5)]
        public decimal? Rating { get; set; }
        public string? Plot { get; set; }

        public List<MovieGenre>? MovieGenres { get; set; }
        public List<MovieActor>? MovieActors { get; set; }
    }
}