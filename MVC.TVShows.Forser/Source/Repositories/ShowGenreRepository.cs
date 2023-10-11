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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return selectedGenres;
        }
    }
}