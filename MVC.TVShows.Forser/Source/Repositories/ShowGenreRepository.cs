using MVC.TVShows.Forser.Data;
using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public class ShowGenreRepository : GenericRepository<Genre>, IShowGenreRepository
    {
        public ShowGenreRepository(TVShowContext context) : base(context) { }
    }
}