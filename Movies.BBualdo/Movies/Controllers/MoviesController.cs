using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        
        public async Task<ActionResult> Index(string? searchString)
        {
            var movies = await _moviesService.GetMovies();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.ToLower().Contains(searchString.ToLower()));
            }
            
            return View(movies);
        }

        public async Task<ActionResult> Details(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie is null) return NotFound("Movie not found.");

            return View(movie);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,ImageUrl")] Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);

            await _moviesService.AddMovie(movie);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie is null) return NotFound("Movie not found.");

            return View(movie);
        }
        
        [HttpPost]
        public async Task<ActionResult> Edit([Bind("Id,Title,ReleaseDate,Genre,Price,ImageUrl")] Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            
            await _moviesService.UpdateMovie(movie);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie is null) return NotFound("Movie not found.");
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie is null) return NotFound("Movie not found.");
            
            await _moviesService.DeleteMovie(movie);
            return RedirectToAction("Index");
        }

    }
}
