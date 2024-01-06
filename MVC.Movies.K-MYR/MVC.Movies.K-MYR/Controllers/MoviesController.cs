using Microsoft.AspNetCore.Mvc;
using MVC.Movies.K_MYR.Data;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Movies.K_MYR;

public class MoviesController : Controller
{
    private readonly MovieContext _context;
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(ILogger<MoviesController> logger, MovieContext context )
    {        
        _logger = logger;        
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString, string movieGenre)
    {
        var genres = _context.Movies.OrderBy(m => m.Genre).Select(m => m.Genre).Distinct();
        var movies = _context.Movies.Select(m => m);

        if(!string.IsNullOrEmpty(searchString))
            movies = movies.Where(s => s.Title.Contains(searchString));

        if (!string.IsNullOrEmpty(movieGenre))    
            movies = movies.Where(x => x.Genre == movieGenre);   

        MovieGenreViewModel movieGenreVM = new()
        {
            Genres = new SelectList(await genres.ToListAsync()),
            Movies = await movies.ToListAsync()
        };

        return View(movieGenreVM);
    }   

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();
        
        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
            return NotFound();

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
    {
        if(id != movie.Id)
            return NotFound();
        
        if (ModelState.IsValid)
        {
            try 
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                    return NotFound();
                else
                    throw;
            }          
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();
        
        var movie = await _context.Movies.FindAsync(id);

        if (movie is null)
            return NotFound();

        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if(movie is null)
            return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));    
    }
  
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]        
    public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,Price,Rating")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    public async Task<ActionResult> Details(int? id)
    {
        if (id is null)
            return NotFound();

        var movie = await _context.Movies.FindAsync(id);       

        if (movie is null)
            return NotFound();
        
        return View(movie);
    }

    private bool MovieExists(int id) => _context.Movies.Find(id) is not null;
}
