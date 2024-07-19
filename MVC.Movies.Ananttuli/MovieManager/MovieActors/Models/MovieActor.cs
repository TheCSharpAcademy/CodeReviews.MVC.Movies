using MovieManager.Movies.Models;
using MovieManager.People.Models;

namespace MovieManager.MovieActors.Models
{
    public class MovieActor
    {
        public int MovieActorId { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
