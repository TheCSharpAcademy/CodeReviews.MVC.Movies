using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Repositories
{
    public class TVShowRepository : GenericRepository<TVShow>, ITVShowRepository
    {
        private readonly TVShowContext _context;
        public TVShowRepository(TVShowContext context) : base(context) 
        {
            _context = context;
        }

        public TVShow GetTVShowById(int id)
        {
            TVShow tvShow = null;
            try
            {
                tvShow = _context.TVShows
                .Include(g => g.Genres)
                .ThenInclude(g => g.Genre)
                .Include(r => r.Ratings)
                .ThenInclude(r => r.Rating)
                .OrderBy(i => i.Id)
                .Where(w => w.Id == id)
                .FirstOrDefault();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return tvShow;
        }
        public async Task DeleteTvShow(TVShow tvShow)
        {
            try
            {
                TVShow exists = await _context.TVShows.FindAsync(tvShow.Id);
                _context.Remove(exists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}