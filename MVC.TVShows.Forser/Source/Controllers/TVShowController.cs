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
            if (id == null || _unitOfWork.TVShows.GetTVShowById(id) == null)
            {
                return NotFound();
            }

            TVShow tvShow = _unitOfWork.TVShows.GetTVShowById(id);
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
                .Select(g => new SelectListItem { Text = g.ShowGenre, Value = g.Id.ToString()}).ToList();
            viewModel.allRatings = (await _unitOfWork.Ratings.GetAll()).ToList()
                .Select(r => new SelectListItem { Text = r.Certification, Value = r.Id.ToString() }).ToList();

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ShowStarted,ShowCompleted,NumberOfEpisodes,NumberOfSeasons,BeenWatched")] TVShow tvShow, List<SelectListItem> allGenres, int Rating)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TVShows.AssignGenresToTVShow(tvShow, allGenres);

                tvShow.TVShow_Rating = new TVShow_Rating { TVShow_Id = tvShow.Id, Rating_Id = Rating };

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

            CreateShowModel viewModel = new CreateShowModel();
            viewModel.tvShow = await _unitOfWork.TVShows.GetById(id);

            await PopulateSelectedGenreCheckboxes(viewModel);
            await PopulateSelectedRatingDropDown(viewModel);

            return View(viewModel);
        }
        private async Task PopulateSelectedRatingDropDown(CreateShowModel viewModel)
        {
            viewModel.allRatings = (await _unitOfWork.Ratings.GetAll()).ToList()
                .Select(r => new SelectListItem { Text = r.Certification, Value = r.Id.ToString(), Selected = r.IsSelected }).ToList();

            var selectedRating = _unitOfWork.Ratings.GetSelectedRating(viewModel.tvShow.Id);

            if (selectedRating != null)
            {
                foreach (var rating in viewModel.allRatings)
                {
                    if (selectedRating.Id == Convert.ToInt32(rating.Value))
                    {
                        rating.Selected = true;
                    }
                }
            }
        }
        private async Task PopulateSelectedGenreCheckboxes(CreateShowModel viewModel)
        {
            viewModel.allGenres = (await _unitOfWork.Genres.GetAll()).ToList()
                .Select(g => new SelectListItem { Text = g.ShowGenre, Value = g.Id.ToString(), Selected = g.Checked }).ToList();

            var selectedGenres = _unitOfWork.Genres.GetSelectedGenres(viewModel.tvShow.Id);

            foreach (var genre in viewModel.allGenres)
            {
                foreach (var selected in selectedGenres)
                {
                    if (selected.Id.ToString() == genre.Value)
                    {
                        genre.Selected = true;
                    }
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateShowModel viewModel, List<SelectListItem> allGenres, int allRatings)
        {
            var exisitingTvShow = await _unitOfWork.TVShows.GetById(id);

            if (exisitingTvShow == null)
            {
                return NotFound();
            }

            if (viewModel.tvShow == null) { return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    exisitingTvShow.Title = viewModel.tvShow.Title;
                    exisitingTvShow.NumberOfEpisodes = viewModel.tvShow.NumberOfEpisodes;
                    exisitingTvShow.NumberOfSeasons = viewModel.tvShow.NumberOfSeasons;
                    exisitingTvShow.BeenWatched = viewModel.tvShow.BeenWatched;
                    exisitingTvShow.ShowStarted = viewModel.tvShow.ShowStarted;
                    exisitingTvShow.ShowCompleted = viewModel.tvShow.ShowCompleted;

                    await _unitOfWork.TVShows.UpdateTvShow(exisitingTvShow, allGenres, allRatings);
                    await _unitOfWork.TVShows.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVShowExists(exisitingTvShow.Id))
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
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                    {
                        foreach (var error in errors)
                        {
                            var errorMessage = error.ErrorMessage;
                            var errorException = error.Exception;

                            Console.WriteLine($"Model binding error for key: {key}, Error: {errorMessage}");

                            if (errorException != null)
                            {
                                Console.WriteLine($"Exception: {errorException.Message}");
                            }
                        }
                    }
                }
            }
            return View(viewModel);
        }
        private bool TVShowExists(int id)
        {
            if (_unitOfWork.TVShows?.GetById(id) != null)
                return true;
            else
                return false;
        }
        public IActionResult Delete(int id)
        {
            if (id == null || _unitOfWork.TVShows.GetTVShowById(id) == null)
            {
                return NotFound();
            }
            var tvShow = _unitOfWork.TVShows.GetTVShowById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return View(tvShow);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TVShow deleteTvShow)
        {
            if (_unitOfWork.TVShows == null)
            {
                return Problem("Entity set 'TVShows'  is null.");
            }
            TVShow tvShow =_unitOfWork.TVShows.GetTVShowById(deleteTvShow.Id);
            if (tvShow != null)
            {
                await _unitOfWork.TVShows.DeleteTvShow(tvShow);
            }

            await _unitOfWork.TVShows.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
