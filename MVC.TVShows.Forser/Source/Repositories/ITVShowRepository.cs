namespace MVC.TVShows.Forser.Repositories
{
    public interface ITVShowRepository : IGenericRepository<TVShow>
    {
        TVShow GetTVShowById(int id);
        Task DeleteTvShow(TVShow tvShow);
        Task UpdateTvShow(TVShow tvShow, List<SelectListItem>? allGenres, int ratingId);
        void AssignGenresToTVShow(TVShow tvShow, List<SelectListItem> allGenres);
    }
}