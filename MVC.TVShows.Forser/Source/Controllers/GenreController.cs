using Microsoft.AspNetCore.Mvc;
using MVC.TVShows.Forser.Models;
using MVC.TVShows.Forser.Repositories;

namespace MVC.TVShows.Forser.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenericRepository<Genre> _genreRepository;

        public GenreController(IGenericRepository<Genre> GenreRepository)
        {
            _genreRepository = GenreRepository;
        }

        // GET: Genre
        public ActionResult Index()
        {
            IEnumerable<Genre> genres = _genreRepository.GetAll();
            return View(genres);
        }

        // GET: Genre/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || (await _genreRepository.GetById(id)) == null)
            {
                return NotFound();
            }

            var genre = await _genreRepository.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowGenre")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.Create(genre);
                await _genreRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        //// GET: Genre/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Genres == null)
        //    {
        //        return NotFound();
        //    }

        //    var genre = await _context.Genres.FindAsync(id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(genre);
        //}

        //// POST: Genre/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ShowGenre")] Genre genre)
        //{
        //    if (id != genre.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(genre);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GenreExists(genre.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(genre);
        //}

        //// GET: Genre/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Genres == null)
        //    {
        //        return NotFound();
        //    }

        //    var genre = await _context.Genres
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (genre == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(genre);
        //}

        //// POST: Genre/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Genres == null)
        //    {
        //        return Problem("Entity set 'TVShowContext.Genres'  is null.");
        //    }
        //    var genre = await _context.Genres.FindAsync(id);
        //    if (genre != null)
        //    {
        //        _context.Genres.Remove(genre);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool GenreExists(int id)
        //{
        //  return (_context.Genres?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
