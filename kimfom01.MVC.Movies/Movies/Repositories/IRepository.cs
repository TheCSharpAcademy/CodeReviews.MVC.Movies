using System.Linq.Expressions;

namespace Movies.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task AddEntities(IEnumerable<TEntity> entities);
    IEnumerable<TEntity> GetEntities();
    Task<TEntity?> GetOneEntity(Expression<Func<TEntity, bool>> expression);
    Task DeleteEntities(IEnumerable<TEntity> entities);
    Task SaveChanges();
}
