using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.TVShows.Forser.Models;
using MVC.TVShows.Forser.Repositories;

namespace MVC.TVShows.Forser.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;           
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Genre> genres = await _unitOfWork.Genres.GetAll();
            return View(genres);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || (await _unitOfWork.Genres.GetById(id)) == null)
            {
                return NotFound();
            }

            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowGenre")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Genres.Create(genre);
                await _unitOfWork.Genres.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        // GET: Genre/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || (await _unitOfWork.Genres.GetById(id)) == null)
            {
                return NotFound();
            }

            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowGenre")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Genres.Update(genre);
                    await _unitOfWork.Genres.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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
            return View(genre);
        }
        private bool GenreExists(int id)
        {
            if(_unitOfWork.Genres.GetById(id) != null)
                return true;
            else
                return false;
        }
        public async Task<IActionResult> Delete(int id)
        {

            if (id == null || (await _unitOfWork.Genres.GetById(id)) == null)
            {
                return NotFound();
            }

            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Genres == null)
            {
                return Problem("Entity set 'Genres'  is null.");
            }
            var genre = await _unitOfWork.Genres.GetById(id);
            if (genre != null)
            {
                await _unitOfWork.Genres.Delete(genre.Id);
            }

            await _unitOfWork.Genres.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
