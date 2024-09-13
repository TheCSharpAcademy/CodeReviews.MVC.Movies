using WatchedList.Application.Repositories;
using WatchedList.Domain.Entities;

namespace WatchedList.Application.Services;

/// <summary>
/// Provides the interactation between any Presentation layers and the Infrastructure layer for the WatchedList repository.
/// </summary>
public class WatchedListService : IWatchedListService
{
    #region Fields

    private readonly IWatchedListRepository _repository;

    #endregion
    #region Constructors

    public WatchedListService(IWatchedListRepository repository)
    {
        _repository = repository;
    }

    #endregion
    #region Methods

    public async Task<int> AddMovieAsync(Movie movie)
    {
        return await _repository.AddMovieAsync(movie);
    }

    public async Task<int> AddRatingAsync(Rating rating)
    {
        return await _repository.AddRatingAsync(rating);
    }

    public async Task<int> AddTheatricalPerformanceAsync(TheatricalPerformance theatricalPerformance)
    {
        return await _repository.AddTheatricalPerformanceAsync(theatricalPerformance);
    }

    public async Task<int> AddTvShowAsync(TvShow tvShow)
    {
        return await _repository.AddTvShowAsync(tvShow);
    }

    public async Task<int> DeleteMovieAsync(Guid id)
    {
        return await _repository.DeleteMovieAsync(id);
    }

    public async Task<int> DeleteTheatricalPerformanceAsync(Guid id)
    {
        return await _repository.DeleteTheatricalPerformanceAsync(id);
    }

    public async Task<int> DeleteTvShowAsync(Guid id)
    {
        return await _repository.DeleteTvShowAsync(id);
    }

    public async Task<Movie?> GetMovieAsync(Guid id)
    {
        return await _repository.GetMovieAsync(id);
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        return await _repository.GetMoviesAsync();
    }

    public async Task<Rating?> GetRatingAsync(int id)
    {
        return await _repository.GetRatingAsync(id);
    }

    public async Task<Rating?> GetRatingAsync(string name)
    {
        return await _repository.GetRatingAsync(name);
    }

    public async Task<List<Rating>> GetRatingsAsync()
    {
        return await _repository.GetRatingsAsync();
    }

    public async Task<TheatricalPerformance?> GetTheatricalPerformanceAsync(Guid id)
    {
        return await _repository.GetTheatricalPerformanceAsync(id);
    }

    public async Task<List<TheatricalPerformance>> GetTheatricalPerformancesAsync()
    {
        return await _repository.GetTheatricalPerformancesAsync();
    }

    public async Task<TvShow?> GetTvShowAsync(Guid id)
    {
        return await _repository.GetTvShowAsync(id);
    }

    public async Task<List<TvShow>> GetTvShowsAsync()
    {
        return await _repository.GetTvShowsAsync();
    }

    public async Task<int> UpdateMovieAsync(Movie movie)
    {
        return await _repository.UpdateMovieAsync(movie);
    }

    public async Task<int> UpdateTheatricalPerformanceAsync(TheatricalPerformance theatricalPerformance)
    {
        return await _repository.UpdateTheatricalPerformanceAsync(theatricalPerformance);
    }

    public async Task<int> UpdateTvShowAsync(TvShow tvShow)
    {
        return await _repository.UpdateTvShowAsync(tvShow);
    }

    #endregion
}
