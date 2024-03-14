using kmakai.MVC.Movies.DataAccess;
using kmakai.MVC.Movies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kmakai.MVC.Movies.Controllers;

[Authorize]
public class MovieController : Controller
{
    private readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index(string searchString)
    {
        var movies = from m in _context.Movies
                     select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(s => s.Title.Contains(searchString));
        }

        return View(movies);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        return View(movie);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}

