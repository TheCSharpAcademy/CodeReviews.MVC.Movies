using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WatchedList.Application.Services;
using WatchedList.Web.Models;

namespace WatchedList.Web.Controllers;

/// <summary>
/// Manages the Movie-related actions for the web application layer.
/// This controller handles the CRUD operations 
/// and also provides filtering and sorting functionalities.
/// </summary>
public class MoviesController : Controller
{
    #region Fields

    private readonly IWatchedListService _service;

    #endregion
    #region Constructors

    public MoviesController(IWatchedListService service)
    {
        _service = service;
    }

    #endregion
    #region Methods

    // GET: Movies
    public async Task<IActionResult> Index(int rating, string searchString, string sortOrder)
    {
        var ratings = await _service.GetRatingsAsync();
        var movies = await _service.GetMoviesAsync();

        if (!string.IsNullOrEmpty(searchString))
        {
            //movies = movies.Where(s => s.Title.ToLower().Contains(searchString.ToLower())).ToList();
            movies = movies.Where(s => s.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (rating > 0)
        {
            movies = movies.Where(r => r.Rating!.Id == rating).ToList();
        }

        var model = new MovieViewModel
        {
            Movies = movies.Select(x => new MovieDto(x)).ToList(),
            Ratings = new SelectList(ratings.Select(x => new RatingDto(x)).OrderBy(o => o.Id).ToList(), "Id", "Name"),

            // Filter:
            RatingId = rating,
            SearchString = searchString,

            // Sort:
            CurrentSort = string.IsNullOrEmpty(sortOrder) ? "title_asc" : sortOrder,
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "",
            WatchDateSort = sortOrder == "watched_asc" ? "watched_desc" : "watched_asc",
            RatingSort = sortOrder == "rating_asc" ? "rating_desc" : "rating_asc"
        };

        model.Movies = sortOrder switch
        {
            "title_desc" => model.Movies.OrderByDescending(o => o.Title).ToList(),
            "watched_asc" => model.Movies.OrderBy(o => o.WatchedDate).ToList(),
            "watched_desc" => model.Movies.OrderByDescending(o => o.WatchedDate).ToList(),
            "rating_asc" => model.Movies.OrderBy(o => o.RatingId).ToList(),
            "rating_desc" => model.Movies.OrderByDescending(o => o.RatingId).ToList(),
            _ => model.Movies.OrderBy(o => o.Title).ToList(),
        };

        return View(model);
    }

    // GET: Movies/Create
    public async Task<IActionResult> Create()
    {
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name");
        return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,WatchedDate,RatingId")] MovieDto movie)
    {
        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(movie.RatingId);
            movie.Rating = new RatingDto(rating);
            await _service.AddMovieAsync(movie.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", movie.RatingId);
        return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _service.GetMovieAsync(id.Value);
        if (movie == null)
        {
            return NotFound();
        }

        var model = new MovieDto(movie);
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", movie.Rating.Id);
        return View(model);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,WatchedDate,RatingId")] MovieDto movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(movie.RatingId);
            movie.Rating = new RatingDto(rating);
            await _service.UpdateMovieAsync(movie.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", movie.RatingId);
        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _service.GetMovieAsync(id.Value);
        if (movie == null)
        {
            return NotFound();
        }

        var model = new MovieDto(movie);
        return View(model);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _service.DeleteMovieAsync(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
