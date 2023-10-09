namespace MVC.TVShows.Forser.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TVShowContext _context;
        public ITVShowRepository TVShows { get; }
        public IShowGenreRepository Genres { get; }
        public IRatingRepository Ratings { get; }

        public UnitOfWork(TVShowContext tvShowContext, ITVShowRepository tvShowRepository, IShowGenreRepository genreRepository, IRatingRepository ratingRepository)
        {
            _context = tvShowContext;
            TVShows = tvShowRepository;
            Genres = genreRepository;
            Ratings = ratingRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}