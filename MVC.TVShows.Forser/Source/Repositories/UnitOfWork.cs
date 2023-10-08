using MVC.TVShows.Forser.Data;

namespace MVC.TVShows.Forser.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TVShowContext _context;
        public ITVShowRepository TVShows { get; }
        public IGenreRepository Genres { get; }

        public UnitOfWork(TVShowContext tvShowContext, ITVShowRepository tvShowRepository, IGenreRepository genreRepository)
        {
            _context = tvShowContext;
            TVShows = tvShowRepository;
            Genres = genreRepository;
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