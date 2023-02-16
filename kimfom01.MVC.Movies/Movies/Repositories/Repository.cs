using Microsoft.EntityFrameworkCore;
using Movies.Data;
using System.Linq.Expressions;

namespace Movies.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieDbContext _movieDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
        _dbSet = movieDbContext.Set<TEntity>();
    }

    public virtual async Task AddEntities(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual Task DeleteEntities(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);

        return Task.CompletedTask;
    }

    public virtual IEnumerable<TEntity> GetEntities()
    {
        return _dbSet.AsNoTracking();
    }

    public virtual async Task<TEntity?> GetOneEntity(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public virtual async Task SaveChanges()
    {
        await _movieDbContext.SaveChangesAsync();
    }
}
