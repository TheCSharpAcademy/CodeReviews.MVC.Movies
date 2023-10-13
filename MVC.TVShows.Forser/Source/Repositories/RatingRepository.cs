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
    }
}