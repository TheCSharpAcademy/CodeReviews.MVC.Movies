using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieManager.Data;
using MovieManager.Models;
using MovieManager.Movies;
using MovieManager.Movies.Models;
using System.Diagnostics;

namespace MovieManager.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieManagerContext _context;
        private readonly MovieRepository _movieRepo;

        public MoviesController(MovieManagerContext context, MovieRepository movieRepo)
        {
            _context = context;
            _movieRepo = movieRepo;
        }

        public async Task<IActionResult> Index(string? searchText, int? selectedGenreId)
        {
            var genres = await _context.Genre.ToListAsync();

            var selectedGenre = selectedGenreId == null ? null :
                genres.Where(g => g.GenreId == selectedGenreId).FirstOrDefault();

            IQueryable<Movie> moviesQuery = _context.Movie
                .Include(m => m.MovieActors!)
                .ThenInclude(movieActor => movieActor.Person)
                .Include(m => m.MovieGenres)
                .AsSplitQuery();

            if (searchText != null && searchText.Trim().Length > 0)
            {
                moviesQuery = moviesQuery.Where(m =>
                    m.Title.ToLower().Contains(searchText.ToLower())
                    ||
                    m.MovieActors!.Where(a =>
                        a.Person.Name.ToLower().Contains(searchText.ToLower())
                    ).Count() > 0
                );
            }

            if (selectedGenre != null)
            {
                moviesQuery = moviesQuery.Where(m =>
                    m.MovieGenres!.Where(movieGenre =>
                        movieGenre.GenreId == selectedGenre.GenreId
                    ).Count() > 0
                );
            }

            var genresSelectList = new SelectList(
                genres,
                "GenreId",
                "Name",
                selectedGenre?.GenreId
            );

            var viewModel = new MovieListViewModel
            {
                SelectedGenreId = selectedGenreId ?? null,
                Genres = genres,
                GenresSelectList = genresSelectList,
                Movies = await moviesQuery.ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.MovieGenres!)
                .ThenInclude(g => g.Genre)
                .Include(m => m.MovieActors!)
                .ThenInclude(a => a.Person)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _context.Genre.ToListAsync();

            var genresSelectList = new MultiSelectList(genres, "GenreId", "Name", null);

            var actors = await _context.Person.ToListAsync();

            var viewModel = new MovieUpsertViewModel
            {
                GenresSelectList = genresSelectList,
                ActorsSelectList = actors.Select(a => new SelectListItem { Value = a.PersonId.ToString(), Text = a.Name })
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "Movie", "Movie.Title", "Movie.Year", "Movie.Rating",
                "Movie.Image", "Movie.Plot", "GenreIds", "ActorPersonIds"
            )]
            MovieUpsertViewModel payload
        )
        {
            if (!ModelState.IsValid)
            {
                return View(payload);
            }

            await _movieRepo.Create(payload.Movie, payload.ActorPersonIds, payload.GenreIds);

            return RedirectToAction(nameof(Details), new { id = payload.Movie.MovieId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.MovieActors!)
                .ThenInclude(movieActor => movieActor.Person)
                .Include(m => m.MovieGenres)
                .Where(m => m.MovieId == id)
                .AsSplitQuery()
                .FirstOrDefaultAsync();


            if (movie == null)
            {
                return NotFound();
            }

            var genres = await _context.Genre.ToListAsync();

            var genresSelectList = new MultiSelectList(genres, "GenreId", "Name", null);

            var actors = await _context.Person.ToListAsync();

            var viewModel = new MovieUpsertViewModel
            {
                Movie = movie,
                GenresSelectList = genresSelectList,
                ActorsSelectList = actors
                    .Select(a => new SelectListItem { Value = a.PersonId.ToString(), Text = a.Name }),
                GenreIds = movie.MovieGenres?
                    .Select(movieGenre => movieGenre.GenreId).ToList() ?? new List<int>(),
                ActorPersonIds = movie.MovieActors?
                    .Select(movieActor => movieActor.PersonId).ToList() ?? new List<int>()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "Movie", "Movie.MovieId", "Movie.Title", "Movie.Year", "Movie.Rating",
                "Movie.Image", "Movie.Plot", "GenreIds", "ActorPersonIds"
            )]
            MovieUpsertViewModel payload)
        {
            var movie = payload.Movie;

            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieRepo.Update(id, movie, payload.ActorPersonIds, payload.GenreIds);

                    return RedirectToAction(nameof(Details), new { id = id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(payload);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
