using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Data;
using MVC.Movies.K_MYR.Models;
using System.Globalization;

namespace MVC.Movies.K_MYR;

public class MoviesController : Controller
{
    private readonly DatabaseContext _context;
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(ILogger<MoviesController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string movieGenre, string movieRating, string yearRange, string priceRange)
    {
        int minYear = 0;
        int maxYear = 0;
        decimal minPrice = 0;
        decimal maxPrice = 0;

        if (_context.Movies.Any())
        {
            minYear = _context.Movies.Min(m => m.ReleaseDate.Year);
            maxYear = _context.Movies.Max(m => m.ReleaseDate.Year);
            minPrice = _context.Movies.Min(m => m.Price);
            maxPrice = _context.Movies.Max(m => m.Price);
        }

        var genres = _context.Movies.Select(m => m.Genre).Distinct().OrderBy(m => m);
        var ratings = _context.Movies.Select(m => m.Rating).Distinct().OrderBy(m => m);
        var movies = _context.Movies.Select(m => m);

        if (!string.IsNullOrEmpty(searchString))
            movies = movies.Where(m => m.Title!.Contains(searchString));

        if (!string.IsNullOrEmpty(movieGenre))
            movies = movies.Where(m => m.Genre == movieGenre);

        if (!string.IsNullOrEmpty(movieRating))
            movies = movies.Where(m => m.Rating == movieRating).OrderBy(m => m.Title);

        if (!string.IsNullOrEmpty(yearRange))
        {
            var years = yearRange.Split(";");

            if (years.Length == 2)
            {
                if (int.TryParse(years[0], out int yearFrom) && int.TryParse(years[1], out int yearTo))
                    movies = movies.Where(m => m.ReleaseDate.Year >= yearFrom && m.ReleaseDate.Year <= yearTo);
            }
        }

        if (!string.IsNullOrEmpty(priceRange))
        {
            var prices = priceRange.Split(";");

            if (prices.Length == 2)
            {
                if (decimal.TryParse(prices[0], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal priceFrom) &&
                    decimal.TryParse(prices[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal priceTo))
                    movies = movies.Where(m => m.Price >= priceFrom && m.Price <= priceTo);
            }
        }

        MovieListViewModel moviesModel = new()
        {
            Genres = new SelectList(await genres.ToListAsync()),
            Ratings = new SelectList(await ratings.ToListAsync()),
            Movies = await movies.OrderBy(m => m.Title).ToListAsync(),
            MinYear = minYear,
            MaxYear = maxYear,
            MinPrice = minPrice,
            MaxPrice = maxPrice
        };

        return View(moviesModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Genre,ReleaseDate,Price,Rating")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            TempData["successMessage"] = "Movie was added successfully.";
        }
        else
        {
            TempData["errorMessage"] = "Bad request: Failed to add the movie.";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
    {
        if (id != movie.Id)
        {
            TempData["errorMessage"] = "Bad request: Failed to update the movie.";
            return Redirect(Request.Headers.Referer.ToString());
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
                TempData["successMessage"] = $"'{movie.Title}' was updated successfully.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(movie.Id))
                    TempData["errorMessage"] = "An error occured while attempting to update the movie: Movie not found.";
                else
                    TempData["errorMessage"] = "An error occured while attempting to update the movie.";
            }
        }
        else
        {
            TempData["errorMessage"] = "Bad request: Failed to update the movie.";
        }

        return Redirect(Request.Headers.Referer.ToString());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
        {
            TempData["errorMessage"] = "An error occured while attempting to update the movie: Movie not found.";
            return RedirectToAction(nameof(Index));
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        TempData["successMessage"] = $"'{movie.Title}' was deleted successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Details(int? id)
    {
        if (id is null)
        {
            TempData["errorMessage"] = "Bad Request: Missing Id.";
            return RedirectToAction(nameof(Index));
        }

        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
        {
            TempData["errorMessage"] = "An error occured while attempting to update the movie: Movie not found.";
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    private async Task<bool> MovieExists(int id) => await _context.Movies.FindAsync(id) is not null;
}
