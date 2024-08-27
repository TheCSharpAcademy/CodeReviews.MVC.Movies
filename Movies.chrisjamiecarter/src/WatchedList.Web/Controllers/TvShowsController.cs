using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WatchedList.Application.Services;
using WatchedList.Web.Models;

namespace WatchedList.Web.Controllers;

/// <summary>
/// Manages the TvShow-related actions for the web application layer.
/// This controller handles the CRUD operations 
/// and also provides filtering and sorting functionalities.
/// </summary>
public class TvShowsController : Controller
{
    #region Fields

    private readonly IWatchedListService _service;

    #endregion
    #region Constructors

    public TvShowsController(IWatchedListService service)
    {
        _service = service;
    }

    #endregion
    #region Methods

    // GET: TvShows
    public async Task<IActionResult> Index(int rating, string searchString, string sortOrder)
    {
        var ratings = await _service.GetRatingsAsync();
        var tvShows = await _service.GetTvShowsAsync();

        if (!string.IsNullOrEmpty(searchString))
        {
            tvShows = tvShows.Where(s => s.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (rating > 0)
        {
            tvShows = tvShows.Where(r => r.Rating!.Id == rating).ToList();
        }

        var model = new TvShowViewModel
        {
            TvShows = tvShows.Select(x => new TvShowDto(x)).ToList(),
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

        model.TvShows = sortOrder switch
        {
            "title_desc" => model.TvShows.OrderByDescending(o => o.Title).ToList(),
            "watched_asc" => model.TvShows.OrderBy(o => o.WatchedDate).ToList(),
            "watched_desc" => model.TvShows.OrderByDescending(o => o.WatchedDate).ToList(),
            "rating_asc" => model.TvShows.OrderBy(o => o.RatingId).ToList(),
            "rating_desc" => model.TvShows.OrderByDescending(o => o.RatingId).ToList(),
            _ => model.TvShows.OrderBy(o => o.Title).ToList(),
        };

        return View(model);
    }

    // GET: TvShows/Create
    public async Task<IActionResult> Create()
    {
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name");
        return View();
    }

    // POST: TvShows/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,WatchedDate,RatingId")] TvShowDto tvShow)
    {
        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(tvShow.RatingId);
            tvShow.Rating = new RatingDto(rating);
            await _service.AddTvShowAsync(tvShow.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", tvShow.RatingId);
        return View(tvShow);
    }

    // GET: TvShows/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tvShow = await _service.GetTvShowAsync(id.Value);
        if (tvShow == null)
        {
            return NotFound();
        }

        var model = new TvShowDto(tvShow);
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", tvShow.Rating.Id);
        return View(model);
    }

    // POST: TvShows/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,WatchedDate,RatingId")] TvShowDto tvShow)
    {
        if (id != tvShow.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(tvShow.RatingId);
            tvShow.Rating = new RatingDto(rating);
            await _service.UpdateTvShowAsync(tvShow.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", tvShow.RatingId);
        return View(tvShow);
    }

    // GET: TvShows/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tvShow = await _service.GetTvShowAsync(id.Value);
        if (tvShow == null)
        {
            return NotFound();
        }

        var model = new TvShowDto(tvShow);
        return View(model);
    }

    // POST: TvShows/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _service.DeleteTvShowAsync(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
