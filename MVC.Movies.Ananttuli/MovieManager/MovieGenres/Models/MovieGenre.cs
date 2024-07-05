using MovieManager.Genres.Models;
using MovieManager.Movies.Models;

namespace MovieManager.MovieGenres.Models
{
    public class MovieGenre
    {
        public int MovieGenreId { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
