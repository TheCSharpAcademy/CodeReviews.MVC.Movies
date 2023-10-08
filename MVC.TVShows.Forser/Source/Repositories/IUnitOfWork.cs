namespace MVC.TVShows.Forser.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITVShowRepository TVShows { get; }
        IGenreRepository Genres { get; }
        int Complete();
    }
}