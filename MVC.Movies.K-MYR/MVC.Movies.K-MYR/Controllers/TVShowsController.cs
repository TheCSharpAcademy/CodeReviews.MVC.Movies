using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Data;
using MVC.Movies.K_MYR.Models;
using System.Globalization;

namespace MVC.Movies.K_MYR.Controllers;
public class TVShowsController : Controller
{
    private readonly DatabaseContext _context;
    private readonly ILogger<TVShowsController> _logger;

    public TVShowsController(ILogger<TVShowsController> logger, DatabaseContext context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ActionResult> Index(string searchString, string showGenre, string showRating, string yearRange, string priceRange)
    {
        int minYear = 0;
        int maxYear = 0;
        decimal minPrice = 0;
        decimal maxPrice = 0;

        if (_context.TVShows.Any())
        {
            minYear = _context.TVShows.Min(m => m.ReleaseDate.Year);
            maxYear = _context.TVShows.Max(m => m.ReleaseDate.Year);
            minPrice = _context.TVShows.Min(m => m.Price);
            maxPrice = _context.TVShows.Max(m => m.Price);
        }

        var genres = _context.TVShows.Select(m => m.Genre).Distinct().OrderBy(m => m);
        var ratings = _context.TVShows.Select(m => m.Rating).Distinct().OrderBy(m => m);
        var tvShows = _context.TVShows.Select(m => m);

        if (!string.IsNullOrEmpty(searchString))
            tvShows = _context.TVShows.Where(t => t.Title!.Contains(searchString));

        if (!string.IsNullOrEmpty(showGenre))
            tvShows = _context.TVShows.Where(t => t.Genre == showGenre);

        if (!string.IsNullOrEmpty(showRating))
            tvShows = tvShows.Where(m => m.Rating == showRating).OrderBy(m => m.Title);

        if (!string.IsNullOrEmpty(yearRange))
        {
            var years = yearRange.Split(";");

            if (years.Length == 2)
            {
                if (int.TryParse(years[0], out int yearFrom) && int.TryParse(years[1], out int yearTo))
                    tvShows = tvShows.Where(m => m.ReleaseDate.Year >= yearFrom && m.ReleaseDate.Year <= yearTo);
            }
        }

        if (!string.IsNullOrEmpty(priceRange))
        {
            var prices = priceRange.Split(";");

            if (prices.Length == 2)
            {
                if (decimal.TryParse(prices[0], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal priceFrom) &&
                    decimal.TryParse(prices[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal priceTo))
                    tvShows = tvShows.Where(m => m.Price >= priceFrom && m.Price <= priceTo);
            }
        }

        TVShowListViewModel tvShowsModel = new()
        {
            TVShows = await tvShows.OrderBy(m => m.Title).ToListAsync(),
            Genres = new SelectList(await genres.ToListAsync()),
            Ratings = new SelectList(await ratings.ToListAsync()),
            MinYear = minYear,
            MaxYear = maxYear,
            MinPrice = minPrice,
            MaxPrice = maxPrice
        };

        return View(tvShowsModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Title,Genre,ReleaseDate,Price,Rating,Seasons")] TVShow show)
    {
        if (ModelState.IsValid)
        {
            _context.Add(show);
            await _context.SaveChangesAsync();
            TempData["successMessage"] = $"'{show.Title}' was added successfully.";
        }
        else
        {
            TempData["errorMessage"] = "Bad request: Failed to add the tv-show.";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id, Title,Genre,ReleaseDate,Price,Rating,Seasons")] TVShow show)
    {
        if (id != show.Id)
        {
            TempData["errorMessage"] = "Bad request: Failed to update the tv-show.";
            return Redirect(Request.Headers.Referer.ToString());
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(show);
                await _context.SaveChangesAsync();
                TempData["successMessage"] = $"'{show.Title}'show was updated successfully.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TVShowExists(show.Id))
                    TempData["errorMessage"] = "An error occured while attempting to update the tv-show: Tv show not found.";
                else
                    TempData["errorMessage"] = "An error occured while attempting to update the tv-show.";
            }
        }
        else
        {
            TempData["errorMessage"] = "Bad request: Failed to update the tv-show.";
        }

        return Redirect(Request.Headers.Referer.ToString());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id)
    {
        var show = await _context.TVShows.FindAsync(id);

        if (show is null)
        {
            TempData["errorMessage"] = "An error occured while attempting to update the movie: TV show not found.";
            return RedirectToAction(nameof(Index));
        }

        _context.TVShows.Remove(show);
        await _context.SaveChangesAsync();

        TempData["successMessage"] = $"{show.Title}' was deleted successfully.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Details(int? id)
    {
        if (id is null)
        {
            TempData["errorMessage"] = "Bad Request: Missing Id.";
            return RedirectToAction(nameof(Index));
        }

        var show = await _context.TVShows.FindAsync(id);

        if (show is null)
        {
            TempData["errorMessage"] = "An error occured while attempting to update the tv show: Movie not found.";
            return RedirectToAction(nameof(Index));
        }

        return View(show);
    }

    private async Task<bool> TVShowExists(int id) => await (_context.TVShows.FindAsync(id)) is not null;
}
