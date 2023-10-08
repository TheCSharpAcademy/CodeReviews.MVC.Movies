using Microsoft.AspNetCore.Mvc;
using MVC.TVShows.Forser.Models;
using MVC.TVShows.Forser.Repositories;

namespace MVC.TVShows.Forser.Controllers
{
    public class TVShowController : Controller
    {
        private readonly IGenericRepository<TVShow> _genericRepository;

        public TVShowController(IGenericRepository<TVShow> GenericRepository)
        {
            _genericRepository = GenericRepository;
        }

        // GET: TVShow
        public ActionResult Index()
        {
            var shows = _genericRepository.GetAll();
            return View(shows);

        }

        //// GET: TVShow/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.TVShows == null)
        //    {
        //        return NotFound();
        //    }

        //    var tVShow = await _context.TVShows
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tVShow == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tVShow);
        //}

        //// GET: TVShow/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TVShow/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched")] TVShow tVShow)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tVShow);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tVShow);
        //}

        //// GET: TVShow/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TVShows == null)
        //    {
        //        return NotFound();
        //    }

        //    var tVShow = await _context.TVShows.FindAsync(id);
        //    if (tVShow == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tVShow);
        //}

        //// POST: TVShow/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched")] TVShow tVShow)
        //{
        //    if (id != tVShow.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tVShow);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TVShowExists(tVShow.Id))
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
        //    return View(tVShow);
        //}

        //// GET: TVShow/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TVShows == null)
        //    {
        //        return NotFound();
        //    }

        //    var tVShow = await _context.TVShows
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tVShow == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tVShow);
        //}

        //// POST: TVShow/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TVShows == null)
        //    {
        //        return Problem("Entity set 'TVShowsContext.TVShows'  is null.");
        //    }
        //    var tVShow = await _context.TVShows.FindAsync(id);
        //    if (tVShow != null)
        //    {
        //        _context.TVShows.Remove(tVShow);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<bool> TVShowExists(int id)
        //{
        //  return ((await TVShowRepository.GetAllShows())?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
