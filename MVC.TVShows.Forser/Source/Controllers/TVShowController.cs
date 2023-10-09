using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.TVShows.Forser.Models;
using MVC.TVShows.Forser.Repositories;

namespace MVC.TVShows.Forser.Controllers
{
    public class TVShowController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TVShowController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: TVShow
        public async Task<IActionResult> Index()
        {
            IEnumerable<TVShow> shows = await _unitOfWork.TVShows.GetAll();
            return View(shows);

        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || (await _unitOfWork.TVShows.GetById(id)) == null)
            {
                return NotFound();
            }

            TVShow tvShow = await _unitOfWork.TVShows.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched")] TVShow tvShow)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.TVShows.Create(tvShow);
                await _unitOfWork.TVShows.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || (await _unitOfWork.TVShows.GetById(id)) == null)
            {
                return NotFound();
            }

            var tvShow = await _unitOfWork.TVShows.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return View(tvShow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched")] TVShow tvShow)
        {
            if (id != tvShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.TVShows.Update(tvShow);
                    await _unitOfWork.TVShows.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVShowExists(tvShow.Id))
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
            return View(tvShow);
        }
        private bool TVShowExists(int id)
        {
            if (_unitOfWork.TVShows?.GetById(id) != null)
                return true;
            else
                return false;
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || (await _unitOfWork.TVShows.GetById(id)) == null)
            {
                return NotFound();
            }
            var tvShow = await _unitOfWork.TVShows.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return View(tvShow);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.TVShows == null)
            {
                return Problem("Entity set 'TVShows'  is null.");
            }
            var tvShow = await _unitOfWork.TVShows.GetById(id);
            if (tvShow != null)
            {
                _unitOfWork.TVShows.Delete(id);
            }

            await _unitOfWork.TVShows.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
