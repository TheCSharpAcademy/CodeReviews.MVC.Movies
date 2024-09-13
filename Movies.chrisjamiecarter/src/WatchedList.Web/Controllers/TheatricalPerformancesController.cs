using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WatchedList.Application.Services;
using WatchedList.Web.Models;

namespace WatchedList.Web.Controllers;

/// <summary>
/// Manages the TheatricalPerformance-related actions for the web application layer.
/// This controller handles the CRUD operations 
/// and also provides filtering and sorting functionalities.
/// </summary>
public class TheatricalPerformancesController : Controller
{
    #region Fields

    private readonly IWatchedListService _service;

    #endregion
    #region Constructors

    public TheatricalPerformancesController(IWatchedListService service)
    {
        _service = service;
    }

    #endregion
    #region Methods

    // GET: TheatricalPerformances
    public async Task<IActionResult> Index(int rating, string searchString, string sortOrder)
    {
        var ratings = await _service.GetRatingsAsync();
        var theatricalPerformances = await _service.GetTheatricalPerformancesAsync();

        if (!string.IsNullOrEmpty(searchString))
        {
            theatricalPerformances = theatricalPerformances.Where(s => s.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (rating > 0)
        {
            theatricalPerformances = theatricalPerformances.Where(r => r.Rating!.Id == rating).ToList();
        }

        var model = new TheatricalPerformanceViewModel
        {
            TheatricalPerformances = theatricalPerformances.Select(x => new TheatricalPerformanceDto(x)).ToList(),
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

        model.TheatricalPerformances = sortOrder switch
        {
            "title_desc" => model.TheatricalPerformances.OrderByDescending(o => o.Title).ToList(),
            "watched_asc" => model.TheatricalPerformances.OrderBy(o => o.WatchedDate).ToList(),
            "watched_desc" => model.TheatricalPerformances.OrderByDescending(o => o.WatchedDate).ToList(),
            "rating_asc" => model.TheatricalPerformances.OrderBy(o => o.RatingId).ToList(),
            "rating_desc" => model.TheatricalPerformances.OrderByDescending(o => o.RatingId).ToList(),
            _ => model.TheatricalPerformances.OrderBy(o => o.Title).ToList(),
        };

        return View(model);
    }

    // GET: TheatricalPerformances/Create
    public async Task<IActionResult> Create()
    {
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name");
        return View();
    }

    // POST: TheatricalPerformances/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,WatchedDate,RatingId")] TheatricalPerformanceDto theatricalPerformance)
    {
        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(theatricalPerformance.RatingId);
            theatricalPerformance.Rating = new RatingDto(rating);
            await _service.AddTheatricalPerformanceAsync(theatricalPerformance.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", theatricalPerformance.RatingId);
        return View(theatricalPerformance);
    }

    // GET: TheatricalPerformances/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theatricalPerformance = await _service.GetTheatricalPerformanceAsync(id.Value);
        if (theatricalPerformance == null)
        {
            return NotFound();
        }

        var model = new TheatricalPerformanceDto(theatricalPerformance);
        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", theatricalPerformance.Rating.Id);
        return View(model);
    }

    // POST: TheatricalPerformances/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,WatchedDate,RatingId")] TheatricalPerformanceDto theatricalPerformance)
    {
        if (id != theatricalPerformance.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var rating = await _service.GetRatingAsync(theatricalPerformance.RatingId);
            theatricalPerformance.Rating = new RatingDto(rating);
            await _service.UpdateTheatricalPerformanceAsync(theatricalPerformance.MapToDomain());
            return RedirectToAction(nameof(Index));
        }

        ViewData["RatingId"] = new SelectList(await _service.GetRatingsAsync(), "Id", "Name", theatricalPerformance.RatingId);
        return View(theatricalPerformance);
    }

    // GET: TheatricalPerformances/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var theatricalPerformance = await _service.GetTheatricalPerformanceAsync(id.Value);
        if (theatricalPerformance == null)
        {
            return NotFound();
        }

        var model = new TheatricalPerformanceDto(theatricalPerformance);
        return View(model);
    }

    // POST: TheatricalPerformances/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _service.DeleteTheatricalPerformanceAsync(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
