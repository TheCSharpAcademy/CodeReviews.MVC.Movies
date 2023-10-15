namespace MVC.TVShows.Forser.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Rating GetSelectedRating(int id);
        Task DeleteRating(Rating rating);
    }
}