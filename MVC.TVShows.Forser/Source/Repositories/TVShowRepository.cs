namespace MVC.TVShows.Forser.Repositories
{
    public class TVShowRepository : GenericRepository<TVShow>, ITVShowRepository
    {
        public TVShowRepository(TVShowContext context) : base(context) { }
    }
}