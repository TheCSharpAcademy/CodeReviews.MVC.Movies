namespace MVC.TVShows.Forser.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(TVShowContext context) : base(context) { }
    }
}