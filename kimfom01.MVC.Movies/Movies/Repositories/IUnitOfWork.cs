namespace Movies.Repositories;

public interface IUnitOfWork: IDisposable
{
    public IMovieRepository Movies { get; set; }
    public ILikedMovieRepository LikedMovies { get; set; }

    public Task<int> SaveChanges();
}