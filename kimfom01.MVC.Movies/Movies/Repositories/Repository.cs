using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.Data;

namespace Movies.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MoviesContext _movieDbContext;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(MoviesContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
        DbSet = movieDbContext.Set<TEntity>();
    }

    public async Task AddEntity(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual async Task AddEntities(IEnumerable<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public virtual Task DeleteEntities(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);

        return Task.CompletedTask;
    }

    public virtual IEnumerable<TEntity> GetEntities()
    {
        return DbSet.AsNoTracking();
    }

    public virtual async Task<TEntity?> GetOneEntity(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.FirstOrDefaultAsync(expression);
    }

    public virtual async Task SaveChanges()
    {
        await _movieDbContext.SaveChangesAsync();
    }
}

