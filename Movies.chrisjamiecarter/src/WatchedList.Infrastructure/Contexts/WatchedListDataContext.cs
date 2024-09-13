using Microsoft.EntityFrameworkCore;
using WatchedList.Infrastructure.Models;

namespace WatchedList.Infrastructure.Contexts;

/// <summary>
/// Represents the Entity Framework Core database context for the WatchedList application.
/// This context provides access to the database tables corresponding to the application's
/// core models, including movies, ratings, theatrical performances, and TV shows.
/// </summary>
internal class WatchedListDataContext : DbContext
{
    #region Constructors

    public WatchedListDataContext(DbContextOptions<WatchedListDataContext> options)
        : base(options)
    {
    }

    #endregion
    #region Properties

    public DbSet<Movie> Movie { get; set; } = default!;

    public DbSet<Rating> Rating { get; set; } = default!;

    public DbSet<TheatricalPerformance> TheatricalPerformance { get; set; } = default!;

    public DbSet<TvShow> TvShow { get; set; } = default!;

    #endregion
}
