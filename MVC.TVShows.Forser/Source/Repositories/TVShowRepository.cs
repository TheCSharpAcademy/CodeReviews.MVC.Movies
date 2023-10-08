using MVC.TVShows.Forser.Data;
using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public class TVShowRepository : ITVShowRepository
    {
        private readonly TVShowContext _context;
        public TVShowRepository(TVShowContext context)
        {
            _context = context;
        }
        public void AddShow(TVShow show)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TVShow> GetAllShows()
        {
            return _context.TVShows.ToList();
        }
        public TVShow GetShowById(int showId)
        {
            throw new NotImplementedException();
        }
        public void RemoveShowById(int showId)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void UpdateShow(TVShow show)
        {
            throw new NotImplementedException();
        }
    }
}