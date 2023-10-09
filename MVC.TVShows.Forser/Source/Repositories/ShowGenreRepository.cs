namespace MVC.TVShows.Forser.Repositories
{
    public class ShowGenreRepository : GenericRepository<Genre>, IShowGenreRepository
    {
        public ShowGenreRepository(TVShowContext context) : base(context) { }
    }
}