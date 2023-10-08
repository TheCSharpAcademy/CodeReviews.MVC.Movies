using MVC.TVShows.Forser.Data;
using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public class TVShowRepository : GenericRepository<TVShow>, ITVShowRepository
    {
        public TVShowRepository(TVShowContext context) : base(context) { }
    }
}