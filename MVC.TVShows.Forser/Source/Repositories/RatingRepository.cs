using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly TVShowContext _context;
        public RatingRepository(TVShowContext context) : base(context) 
        {
            _context = context;
        }
        public Rating GetSelectedRating(int id)
        {
            Rating selectedRating = null;

            try
            {
                selectedRating = _context.TVShowRatings
                    .Where(r => r.TVShow_Id == id)
                    .Select(tg => tg.Rating)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return selectedRating;
        }

        public async Task DeleteRating(Rating rating)
        {
            try
            {
                Rating exists = await _context.Ratings.FindAsync(rating.Id);
                _context.Remove(exists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}