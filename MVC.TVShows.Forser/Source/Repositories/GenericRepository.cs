namespace MVC.TVShows.Forser.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TVShowContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(TVShowContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task Create(T entity) => await _context.AddAsync(entity);

        public async Task Delete(T entity)
        {
            T existing = await _entities.FindAsync(entity);
            _entities.Remove(existing);
        }

        public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

        public async Task<T> GetById(int id) => await _entities.FindAsync(id);

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public TVShow GetAllById(int id)
        {
            return _context.TVShows
                .Include(i => i.Genres)
                .ThenInclude(i => i.Genre)
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .Where(w => w.Id == id)
                .FirstOrDefault();
        }
    }
}