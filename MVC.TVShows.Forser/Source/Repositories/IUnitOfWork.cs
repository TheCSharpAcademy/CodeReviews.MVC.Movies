namespace MVC.TVShows.Forser.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITVShowRepository TVShows { get; }
        IShowGenreRepository Genres { get; }
        IRatingRepository Ratings { get; }
        int Complete();
    }
}