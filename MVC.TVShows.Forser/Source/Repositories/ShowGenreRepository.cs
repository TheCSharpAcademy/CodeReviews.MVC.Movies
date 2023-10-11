namespace MVC.TVShows.Forser.Repositories
{
    public class ShowGenreRepository : GenericRepository<Genre>, IShowGenreRepository
    {
        private readonly TVShowContext _context;
        public ShowGenreRepository(TVShowContext context) : base(context) 
        {
            _context = context;
        }
        public List<Genre> GetSelectedGenres(int id)
        {
            List<Genre> selectedGenres = null;
            try
            {
                selectedGenres = _context.TVShowGenres
                    .Where(tg => tg.TVShow_Id == id)
                    .Select(tg => tg.Genre)
                    .ToList();
                    
                //_context.TVShows
                //.Include(g => g.Genres)
                //.ThenInclude(g => g.Genre)
                //.Include(r => r.Ratings)
                //.ThenInclude(r => r.Rating)
                //.OrderBy(i => i.Id)
                //.Where(w => w.Id == id)
                //.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return selectedGenres;
        }
    }
}