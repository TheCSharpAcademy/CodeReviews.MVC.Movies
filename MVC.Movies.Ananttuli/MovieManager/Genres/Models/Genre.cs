using MovieManager.MovieGenres.Models;

namespace MovieManager.Genres.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }

        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
