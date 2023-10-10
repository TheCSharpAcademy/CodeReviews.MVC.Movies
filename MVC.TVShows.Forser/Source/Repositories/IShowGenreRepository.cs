namespace MVC.TVShows.Forser.Repositories
{
    public interface IShowGenreRepository : IGenericRepository<Genre>
    {
        List<Genre> GetSelectedGenres(int id);
    }
}