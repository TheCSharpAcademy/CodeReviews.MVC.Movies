using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesMVCCarDioLogic.Data;
using MoviesMVCCarDioLogic.Models;

namespace MoviesMVCCarDioLogic.Controllers
{
    public class SeriesController : Controller
    {
        private readonly MoviesMVCCarDioLogicContext _context;
        public SeriesController(MoviesMVCCarDioLogicContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string serieGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Serie
                                            orderby m.Genre
                                            select m.Genre;

            var series = from m in _context.Serie
                         select m;

            if(!string.IsNullOrEmpty(searchString))
            {
                series = series.Where(s => s.Title!.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(serieGenre))
            {
                series = series.Where(x => x.Genre ==  serieGenre);
            }

            var serieGenreVM = new SerieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Series = await series.ToListAsync()
            };


            return View(serieGenreVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Serie == null) 
            {
                return NotFound();
            }

            var serie = await _context.Serie.FirstOrDefaultAsync();

            if(serie == null) 
            {
                return NotFound();
            }

            return View(serie);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,NumberOfEpisodes,NumberOfSeasons,StreamingPlatform,Rating")] Serie serie)
        {
            if(ModelState.IsValid) 
            {
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(serie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Serie == null)
            {
                return NotFound();
            }

            var serie = await _context.Serie.FindAsync(id);
            if(serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, ReleaseDate, Genre, NumberOfEpisodes, NumberOfSeasons, StreamingPlatform, Rating")] Serie serie)
        {
            if(id != serie.Id) 
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(serie);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!SerieExists(serie.Id)) 
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

            return View(serie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Serie == null)
            {
                return NotFound(); 
            }

            var serie = await _context.Serie.FirstOrDefaultAsync(s => s.Id == id);

            if(serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Serie == null)
            {
                return Problem("Entity set 'MoviesMVCCarDioLogicContext.Serie'  is null.");
            }
            var serie = await _context.Serie.FindAsync(id);
            if(serie != null) 
            {
                _context.Serie.Remove(serie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerieExists(int id)
        {
            return (_context.Serie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
