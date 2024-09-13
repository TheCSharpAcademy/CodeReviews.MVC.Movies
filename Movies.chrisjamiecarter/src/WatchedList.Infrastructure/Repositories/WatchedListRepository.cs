using Microsoft.EntityFrameworkCore;
using WatchedList.Application.Repositories;
using WatchedList.Domain.Entities;
using WatchedList.Infrastructure.Contexts;

namespace WatchedList.Infrastructure.Repositories;

/// <summary>
/// Provides repository operations for managing the Infrastructure layer's entities.
/// This class implements the <see cref="IWatchedListRepository"/> interface, offering 
/// methods to perform CRUD operations against the database using Entity Framework Core.
/// </summary>
internal class WatchedListRepository : IWatchedListRepository
{
    #region Fields

    private readonly WatchedListDataContext _context;

    #endregion
    #region Constructors

    public WatchedListRepository(WatchedListDataContext context)
    {
        _context = context;
    }

    #endregion
    #region Methods

    public async Task<int> AddMovieAsync(Movie entity)
    {
        var model = new Models.Movie
        {
            Id = Guid.NewGuid(),
            Title = entity.Title,
            WatchedDate = entity.WatchedDate,
            RatingId = entity.Rating.Id,
        };

        _context.Add(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AddRatingAsync(Rating entity)
    {
        var model = new Models.Rating
        {
            Name = entity.Name,
        };

        _context.Add(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AddTheatricalPerformanceAsync(TheatricalPerformance entity)
    {
        var model = new Models.TheatricalPerformance
        {
            Id = Guid.NewGuid(),
            Title = entity.Title,
            WatchedDate = entity.WatchedDate,
            RatingId = entity.Rating.Id,
        };

        _context.Add(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AddTvShowAsync(TvShow entity)
    {
        var model = new Models.TvShow
        {
            Id = Guid.NewGuid(),
            Title = entity.Title,
            WatchedDate = entity.WatchedDate,
            RatingId = entity.Rating.Id,
        };

        _context.Add(model);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteMovieAsync(Guid id)
    {
        var model = await _context.Movie.FindAsync(id);
        if (model != null)
        {
            _context.Movie.Remove(model);
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteTheatricalPerformanceAsync(Guid id)
    {
        var model = await _context.TheatricalPerformance.FindAsync(id);
        if (model != null)
        {
            _context.TheatricalPerformance.Remove(model);
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteTvShowAsync(Guid id)
    {
        var model = await _context.TvShow.FindAsync(id);
        if (model != null)
        {
            _context.TvShow.Remove(model);
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<Movie?> GetMovieAsync(Guid id)
    {
        var model = await _context.Movie.FindAsync(id);
        if (model is null)
        {
            return null;
        }

        if (model.Rating is null)
        {
            model = await _context.Movie.Include(x => x.Rating).SingleOrDefaultAsync(x => x.Id == model.Id);
            if (model is null)
            {
                return null;
            }
        }

        return model.MapToDomain();
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        var models = await _context.Movie.ToListAsync();
        return models.Select(x => x.MapToDomain()).ToList();
    }

    public async Task<Rating?> GetRatingAsync(int id)
    {
        var model = await _context.Rating.FindAsync(id);
        if (model == null)
        {
            return null;
        }

        return model.MapToDomain();
    }

    public async Task<Rating?> GetRatingAsync(string name)
    {
        var model = await _context.Rating.FirstOrDefaultAsync(x => x.Name == name);
        if (model == null)
        {
            return null;
        }

        return model.MapToDomain();
    }

    public async Task<List<Rating>> GetRatingsAsync()
    {
        var models = await _context.Rating.ToListAsync();
        return models.Select(x => x.MapToDomain()).ToList();
    }

    public async Task<TheatricalPerformance?> GetTheatricalPerformanceAsync(Guid id)
    {
        var model = await _context.TheatricalPerformance.FindAsync(id);
        if (model == null)
        {
            return null;
        }

        if (model.Rating is null)
        {
            model = await _context.TheatricalPerformance.Include(x => x.Rating).SingleOrDefaultAsync(x => x.Id == model.Id);
            if (model is null)
            {
                return null;
            }
        }

        return model.MapToDomain();
    }

    public async Task<List<TheatricalPerformance>> GetTheatricalPerformancesAsync()
    {
        var models = await _context.TheatricalPerformance.ToListAsync();
        return models.Select(x => x.MapToDomain()).ToList();
    }

    public async Task<TvShow?> GetTvShowAsync(Guid id)
    {
        var model = await _context.TvShow.FindAsync(id);
        if (model == null)
        {
            return null;
        }

        if (model.Rating is null)
        {
            model = await _context.TvShow.Include(x => x.Rating).SingleOrDefaultAsync(x => x.Id == model.Id);
            if (model is null)
            {
                return null;
            }
        }

        return model.MapToDomain();
    }

    public async Task<List<TvShow>> GetTvShowsAsync()
    {
        var models = await _context.TvShow.ToListAsync();
        return models.Select(x => x.MapToDomain()).ToList();
    }

    public async Task<int> UpdateMovieAsync(Movie entity)
    {
        var model = await _context.Movie.FindAsync(entity.Id);
        if (model == null)
        {
            return 0;
        }

        model.Title = entity.Title;
        model.WatchedDate = entity.WatchedDate;
        model.RatingId = entity.Rating.Id;

        try
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MovieExists(model.Id))
            {
                return 0;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<int> UpdateTheatricalPerformanceAsync(TheatricalPerformance entity)
    {
        var model = await _context.TheatricalPerformance.FindAsync(entity.Id);
        if (model == null)
        {
            return 0;
        }

        model.Title = entity.Title;
        model.WatchedDate = entity.WatchedDate;
        model.RatingId = entity.Rating.Id;

        try
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TheatricalPerformanceExists(model.Id))
            {
                return 0;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<int> UpdateTvShowAsync(TvShow entity)
    {
        var model = await _context.TvShow.FindAsync(entity.Id);
        if (model == null)
        {
            return 0;
        }

        model.Title = entity.Title;
        model.WatchedDate = entity.WatchedDate;
        model.RatingId = entity.Rating.Id;

        try
        {
            _context.Update(model);
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TvShowExists(model.Id))
            {
                return 0;
            }
            else
            {
                throw;
            }
        }
    }

    private bool MovieExists(Guid id)
    {
        return _context.Movie.Any(e => e.Id == id);
    }

    private bool TheatricalPerformanceExists(Guid id)
    {
        return _context.TheatricalPerformance.Any(e => e.Id == id);
    }

    private bool TvShowExists(Guid id)
    {
        return _context.TvShow.Any(e => e.Id == id);
    }

    #endregion
}
