using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.wkktoria.Data;
using Movies.wkktoria.Models;

namespace Movies.wkktoria.Controllers;

public class AlbumsController : Controller
{
    private readonly AppDbContext _context;

    public AlbumsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Albums
    public async Task<IActionResult> Index(string searchString, string albumGenre)
    {
        var genreQuery = from a in _context.Albums orderby a.Genre select a.Genre;
        var albums = from a in _context.Albums select a;

        if (!string.IsNullOrEmpty(searchString)) albums = albums.Where(m => m.Title!.Contains(searchString));
        if (!string.IsNullOrEmpty(albumGenre)) albums = albums.Where(m => m.Genre == albumGenre);

        var albumGenreVm = new AlbumGenreViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Albums = await albums.ToListAsync()
        };

        return View(albumGenreVm);
    }

    // GET: Albums/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Albums == null) return NotFound();

        var album = await _context.Albums
            .FirstOrDefaultAsync(a => a.Id == id);

        if (album == null) return NotFound();

        return View(album);
    }

    // GET: Albums/Add
    public IActionResult Add()
    {
        return View();
    }

    // POST: Albums/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add([Bind("")] Album album)
    {
        if (!ModelState.IsValid) return View(album);

        _context.Add(album);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: Albums/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Albums == null) return NotFound();

        var album = await _context.Albums.FindAsync(id);

        if (album == null) return NotFound();

        return View(album);
    }

    // POST: Albums/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,CoverPath,Artist,Title,ReleaseDate,Genre")] Album album)
    {
        if (id != album.Id) return NotFound();

        if (!ModelState.IsValid) return View(album);

        try
        {
            _context.Update(album);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlbumExists(album.Id)) return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Albums/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Albums == null) return NotFound();

        var album = await _context.Albums.FirstOrDefaultAsync(album => album.Id == id);

        if (album == null) return NotFound();

        return View(album);
    }

    // POST: Albums/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Albums == null) return NotFound();

        var album = await _context.Albums.FindAsync(id);

        if (album != null) _context.Albums.Remove(album);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool AlbumExists(long id)
    {
        return (_context.Albums?.Any(album => album.Id == id)).GetValueOrDefault();
    }
}