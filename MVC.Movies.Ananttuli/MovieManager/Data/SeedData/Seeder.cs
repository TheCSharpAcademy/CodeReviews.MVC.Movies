using MovieManager.Genres.Models;
using MovieManager.MovieActors.Models;
using MovieManager.MovieGenres.Models;
using MovieManager.Movies.Models;
using MovieManager.People.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieManager.Data.SeedData
{
    public class Seeder
    {
        private readonly IServiceProvider _serviceProvider;

        public Seeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SeedIfNoMovies()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<MovieManagerContext>();

                if (_context.Movie.Any())
                {
                    return;
                }

                var moviesReadStream = File.OpenRead("Data/SeedData/DataSets/movies.json");
                var moviesJson = JsonDocument.Parse(moviesReadStream);

                var parsedMovies = JsonSerializer.Deserialize<List<MovieJson>>(moviesJson);

                var genres = new List<Genre>();
                var persons = new List<Person>();

                foreach (var parsedMovie in parsedMovies ?? [])
                {
                    var genresForMovie = parsedMovie.Genres.Select((parsedGenre) =>
                    {
                        var existingGenre = genres.Where(g => g.Name == parsedGenre).FirstOrDefault();
                        if (existingGenre != null)
                        {
                            return existingGenre;
                        }
                        else
                        {
                            var newGenre = new Genre
                            {
                                Name = parsedGenre
                            };

                            _context.Genre.Add(newGenre);
                            _context.SaveChanges();
                            genres.Add(newGenre);
                            return newGenre;
                        }
                    }).ToList();


                    var movie = new Movie
                    {
                        Title = parsedMovie.Title,
                        Year = parsedMovie.Year,
                        Image = parsedMovie.Image,
                        Color = parsedMovie.Color,
                        Rating = parsedMovie.Rating,
                        Plot = parsedMovie.Plot
                    };

                    _context.Movie.Add(movie);
                    _context.SaveChanges();

                    _context.MovieGenre.AddRange(
                        genresForMovie.Select(g => new MovieGenre
                        {
                            MovieId = movie.MovieId,
                            GenreId = g.GenreId
                        })
                    );

                    _context.SaveChanges();

                    var actorsForMovie = parsedMovie.Actors.Select((parsedActor, i) =>
                    {
                        var existingPerson = persons.Where(p => p.Name == parsedActor).FirstOrDefault();
                        if (existingPerson != null)
                        {
                            return existingPerson;
                        }
                        else
                        {
                            var newPerson = new Person
                            {
                                Name = parsedActor,
                                Thumbnail = parsedMovie.Actor_Facets?[i] ?? ""
                            };

                            _context.Person.Add(newPerson);
                            _context.SaveChanges();

                            persons.Add(newPerson);
                            return newPerson;
                        }
                    });

                    _context.MovieActor.AddRange(
                        actorsForMovie.Select(p => new MovieActor
                        {
                            MovieId = movie.MovieId,
                            PersonId = p.PersonId
                        })
                    );

                    _context.SaveChanges();
                }
            }

        }
    }
}

internal record class MovieJson
{
    [JsonPropertyName("title")] public string Title { get; set; }
    [JsonPropertyName("year")] public int Year { get; set; }
    [JsonPropertyName("image")] public string Image { get; set; }
    [JsonPropertyName("color")] public string Color { get; set; }
    [JsonPropertyName("rating")] public decimal Rating { get; set; }
    [JsonPropertyName("actors")] public List<string> Actors { get; set; }
    [JsonPropertyName("actor_facets")] public List<string> Actor_Facets { get; set; }
    [JsonPropertyName("genre")] public List<string> Genres { get; set; }
    [JsonPropertyName("plot")] public string? Plot { get; set; }
}
