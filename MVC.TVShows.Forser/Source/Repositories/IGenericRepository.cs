namespace MVC.TVShows.Forser.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        TVShow GetAllById(int id);
        Task<T> GetById(int id);
        Task Create(T entity);
        void Update(T entity);
        Task Delete(T entity);
        Task Save();
    }
}