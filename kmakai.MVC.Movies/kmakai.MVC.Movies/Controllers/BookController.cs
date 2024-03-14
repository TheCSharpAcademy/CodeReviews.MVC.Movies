using kmakai.MVC.Movies.DataAccess;
using kmakai.MVC.Movies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kmakai.MVC.Movies.Controllers;

[Authorize]
public class BookController : Controller
{

    private readonly AppDbContext _context;


    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index(string searchString)
    {
        var books = from b in _context.Books
                    select b;
        if(!String.IsNullOrEmpty(searchString))
        {
            books = books.Where(s => s.Title.Contains(searchString) || s.Author.Contains(searchString));
        }

        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Title,Author,Published,Genre,Price")] Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(book);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Published,Genre,Price")] Book book)
    {
        if(id != book.Id)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, [Bind("Id,Title,Author,Published,Genre,Price")] Book book)
    {
        if(id != book.Id)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
