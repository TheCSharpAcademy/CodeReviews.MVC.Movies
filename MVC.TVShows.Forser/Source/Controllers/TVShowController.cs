using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.TVShows.Forser.Controllers
{
    public class TVShowController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TVShowController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<TVShow> shows = await _unitOfWork.TVShows.GetAll();

            return View(shows);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _unitOfWork.TVShows.GetAllById(id) == null)
            {
                return NotFound();
            }

            TVShow tvShow = _unitOfWork.TVShows.GetAllById(id);
            if (tvShow == null)
            {
                return NotFound();
            }

            return View(tvShow);
        }
        public async Task<IActionResult> Create()
        {
            CreateShowModel viewModel = new CreateShowModel();
            viewModel.allGenres = (await _unitOfWork.Genres.GetAll()).ToList()
                .Select(m => new SelectListItem { Text = m.ShowGenre, Value = m.Id.ToString()}).ToList();

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched,Genres")] TVShow tvShow, List<SelectListItem> allGenres)
        {
            if (ModelState.IsValid)
            {
                List<Genre> listOfGenre = generateGenreList(allGenres);
                List<TVShow_Genre> tvShow_Genres = new List<TVShow_Genre>();

                foreach(Genre genre in listOfGenre)
                {
                    tvShow_Genres.Add(
                        new TVShow_Genre 
                        { 
                            Genre_Id = genre.Id,
                            TVShow_Id = tvShow.Id
                        }
                    );
                }
                tvShow.Genres = tvShow_Genres;

                await _unitOfWork.TVShows.Create(tvShow);
                await _unitOfWork.TVShows.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }

        private List<Genre> generateGenreList(List<SelectListItem> selectedGenres)
        {
            List<Genre> generatedGenreList = new List<Genre>();

            var temp = selectedGenres.Where(s => s.Selected == true);

            foreach (var genre in temp)
            {
                    generatedGenreList.Add(
                        new Genre { 
                            Id = Convert.ToInt32(genre.Value), ShowGenre = genre.Text, Checked = genre.Selected 
                        });
            }

            return generatedGenreList;
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
            TVShow tvShow = await _unitOfWork.TVShows.GetById(id);
            if (tvShow != null)
            {
                await _unitOfWork.TVShows.Delete(tvShow);
            }

            await _unitOfWork.TVShows.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
