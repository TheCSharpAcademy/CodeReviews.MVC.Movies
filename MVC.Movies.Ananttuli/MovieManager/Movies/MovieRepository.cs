using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.MovieActors.Models;
using MovieManager.MovieGenres.Models;
using MovieManager.Movies.Models;

namespace MovieManager.Movies
{
    public class MovieRepository
    {
        MovieManagerContext _context;

        public MovieRepository(MovieManagerContext context)
        {
            _context = context;
        }


        public async Task Create(Movie movie, List<int>? actorPersonIds, List<int>? genreIds)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            await RecreateGenresAndActors(movie, actorPersonIds, genreIds);
        }


        public async Task Update(int id, Movie movie, List<int>? actorPersonIds, List<int>? genreIds)
        {
            var query = _context.Movie
                        .Include(m => m.MovieActors!)
                        .ThenInclude(movieActor => movieActor.Person)
                        .Include(m => m.MovieGenres)
                        .AsSplitQuery();

            var existingMovie = await
                query.Where(m => m.MovieId == id).FirstOrDefaultAsync();


            if (existingMovie == null)
            {
                throw new Exception("Could not find movie");
            }

            await RecreateGenresAndActors(existingMovie, actorPersonIds, genreIds);

            existingMovie.Title = movie.Title;
            existingMovie.Year = movie.Year;
            existingMovie.Rating = movie.Rating;
            existingMovie.Image = movie.Image;
            existingMovie.Plot = movie.Plot;

            _context.Update(existingMovie);

            await _context.SaveChangesAsync();
        }

        private async Task RecreateGenresAndActors(Movie movie, List<int>? actorPersonIds, List<int>? genreIds)
        {
            if (movie.MovieGenres?.Count > 0)
            {
                _context.MovieGenre.RemoveRange(movie.MovieGenres);
            }

            if (movie.MovieActors?.Count > 0)
            {
                _context.MovieActor.RemoveRange(movie.MovieActors);
            }

            await _context.SaveChangesAsync();

            _context.MovieActor.AddRange(
                (actorPersonIds ?? []).Select(actorPersonId =>
                new MovieActor
                {
                    MovieId = movie.MovieId,
                    PersonId = actorPersonId
                })
            );

            _context.MovieGenre.AddRange(
                (genreIds ?? []).Select(genreId =>
                new MovieGenre
                {
                    MovieId = movie.MovieId,
                    GenreId = genreId
                })
            );

            await _context.SaveChangesAsync();
        }
    }
}
