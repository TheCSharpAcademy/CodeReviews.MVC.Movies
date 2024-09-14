using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class MoviesService(MovieDbContext dbContext) : IMoviesService
{
    private readonly MovieDbContext _dbContext = dbContext;
    
    public async Task<IEnumerable<Movie>> GetMovies()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task<Movie?> GetMovieById(int id)
    {
        return await _dbContext.Movies.FindAsync(id);
    }

    public async Task AddMovie(Movie movie)
    {
        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMovie(Movie movie)
    {
        _dbContext.Entry(movie).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteMovie(Movie movie)
    {
        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync();
    }
}