using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Controllers;

public class TvShows(MovieContext context) : Controller
{
    private readonly MovieContext _context = context;

    public List<TvShow> Shows = [];


    public async Task<IActionResult> Index(string movieGenre, string searchString)
    {
        if(_context.TvShow is null)
        {
            return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        }

        var shows = _context.TvShow.AsQueryable();

        if(searchString is not null)
        {
            shows = shows.Where(p => p.Title!.Contains(searchString));
        }

        if(movieGenre is not null)
        {
            shows = shows.Where( p => p.Genre == movieGenre);
        }

        Shows = await shows.ToListAsync();
        return View(Shows);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if(id is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var show = await _context.TvShow.FindAsync( id);

        if(show is null)
        {
            return NotFound();
        }
        return View(show);        
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if(id is null)
        {
            return RedirectToAction(nameof(Index));
        }

        var show = await _context.TvShow.FindAsync( id);

        if(show is null)
        {
            return NotFound();
        }
        return View(show);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] TvShow show)
    {
        if(!ModelState.IsValid)
        {
            return View(show);
        }

        if(!id.Equals(show.Id))
            return NotFound();

        _context.TvShow.Update(show);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DBConcurrencyException)
        {
            if (!_context.TvShow.Any(p => p.Id.Equals(id)))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        var show = await _context.TvShow.FindAsync(id);
        if(show is null || id is null)
        {
            return NotFound();
        }
        return View(show);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int? id)
    {

    }
}
