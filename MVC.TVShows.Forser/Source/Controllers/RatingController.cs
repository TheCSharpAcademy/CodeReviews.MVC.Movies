namespace MVC.TVShows.Forser.Controllers
{
    public class RatingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Rating> ratings = await _unitOfWork.Ratings.GetAll();
            return View(ratings);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || (await _unitOfWork.Ratings.GetById(id)) == null)
            {
                return NotFound();
            }

            var rating = await _unitOfWork.Ratings.GetById(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,Certification,Description")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Ratings.Create(rating);
                await _unitOfWork.Ratings.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }
        // GET: Rating/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || (await _unitOfWork.Ratings.GetById(id)) == null)
            {
                return NotFound();
            }

            var rating = await _unitOfWork.Ratings.GetById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,Certification,Description")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Ratings.Update(rating);
                    await _unitOfWork.Ratings.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            return View(rating);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || (await _unitOfWork.Ratings.GetById(id)) == null)
            {
                return NotFound();
            }
            var rating = await _unitOfWork.Ratings.GetById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Ratings == null)
            {
                return Problem("Entity set 'Ratings'  is null.");
            }
            Rating rating = await _unitOfWork.Ratings.GetById(id);
            if (rating != null)
            {
                await _unitOfWork.Ratings.DeleteRating(rating);
            }
            await _unitOfWork.Ratings.Save();
            return RedirectToAction(nameof(Index));
        }
        private bool RatingExists(int id)
        {
            if (_unitOfWork.Ratings.GetById(id) != null)
                return true;
            else
                return false;
        }
    }
}
