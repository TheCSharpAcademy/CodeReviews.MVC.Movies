using WatchedList.Application.Repositories;
using WatchedList.Domain.Entities;

namespace WatchedList.Infrastructure.Services;

/// <summary>
/// Provides methods to seed the database with initial data.
/// This service ensures that the required Rating objects are populated in the database if they do
/// not already exist, and any optional Movie, TV Show and Theatrical Performace objects are created.
/// </summary>
internal class SeederService
{
    #region Fields

    private static readonly IEnumerable<Rating> _ratings =
    [
        new Rating { Name = "Awful" },
        new Rating { Name = "Disappointing" },
        new Rating { Name = "Good" },
        new Rating { Name = "Great" },
        new Rating { Name = "Excellent" }
    ];

    #endregion
    #region Methods

    public static void SeedDatabase(IWatchedListRepository repository)
    {
        // Required.
        SeedRating(repository);

        // Optional.
        SeedMovies(repository);
        SeedTheatricalPerformances(repository);
        SeedTvShows(repository);
    }

    private static void SeedRating(IWatchedListRepository repository)
    {
        var ratings = repository.GetRatingsAsync().Result;

        foreach (Rating rating in _ratings)
        {
            if (ratings.SingleOrDefault(x => x.Name == rating.Name) is null)
            {
                _ = repository.AddRatingAsync(rating).Result;
            }
        }
    }

    private static void SeedMovies(IWatchedListRepository repository)
    {
        if (repository.GetMoviesAsync().Result.Count > 0)
        {
            return;
        }

        var ratings = repository.GetRatingsAsync().Result;

        _ = repository.AddMovieAsync(new Movie
        {
            Title = "Titanic",
            WatchedDate = DateTime.Parse("1997-12-19"),
            Rating = ratings.Single(x => x.Name == "Good")
        }).Result;

        _ = repository.AddMovieAsync(new Movie
        {
            Title = "E.T. the Extra-Terrestrial",
            WatchedDate = DateTime.Parse("1982-06-11"),
            Rating = ratings.Single(x => x.Name == "Good")
        }).Result;

        _ = repository.AddMovieAsync(new Movie
        {
            Id = Guid.NewGuid(),
            Title = "Star Wars: Episode IV - A New Hope",
            WatchedDate = DateTime.Parse("1977-05-25"),
            Rating = ratings.Single(x => x.Name == "Great")
        }).Result;

        _ = repository.AddMovieAsync(new Movie
        {

            Title = "The Lord of the Rings: The Return of the King",
            WatchedDate = DateTime.Parse("2003-12-17"),
            Rating = ratings.Single(x => x.Name == "Excellent")
        }).Result;

        _ = repository.AddMovieAsync(new Movie
        {
            Title = "Batman & Robin",
            WatchedDate = DateTime.Parse("1997-06-20"),
            Rating = ratings.Single(x => x.Name == "Awful")
        }).Result;

        _ = repository.AddMovieAsync(new Movie
        {
            Title = "Jingle All the Way",
            WatchedDate = DateTime.Parse("1996-11-22"),
            Rating = ratings.Single(x => x.Name == "Disappointing")
        }).Result;
    }

    private static void SeedTvShows(IWatchedListRepository repository)
    {
        if (repository.GetTvShowsAsync().Result.Count > 0)
        {
            return;
        }

        var ratings = repository.GetRatingsAsync().Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "Game of Thrones",
            WatchedDate = DateTime.Parse("2011-04-17"),
            Rating = ratings.Single(x => x.Name == "Excellent")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "Stranger Things",
            WatchedDate = DateTime.Parse("2016-07-15"),
            Rating = ratings.Single(x => x.Name == "Great")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "Sons of Anarchy",
            WatchedDate = DateTime.Parse("2008-09-03"),
            Rating = ratings.Single(x => x.Name == "Good")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "The Walking Dead",
            WatchedDate = DateTime.Parse("2010-10-31"),
            Rating = ratings.Single(x => x.Name == "Great")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "Breaking Bad",
            WatchedDate = DateTime.Parse("2008-01-20"),
            Rating = ratings.Single(x => x.Name == "Excellent")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "Baywatch",
            WatchedDate = DateTime.Parse("1989-09-22"),
            Rating = ratings.Single(x => x.Name == "Disappointing")
        }).Result;

        _ = repository.AddTvShowAsync(new TvShow
        {
            Title = "The Brady Bunch Variety Hour",
            WatchedDate = DateTime.Parse("1976-11-28"),
            Rating = ratings.Single(x => x.Name == "Awful")
        }).Result;
    }

    private static void SeedTheatricalPerformances(IWatchedListRepository repository)
    {
        if (repository.GetTheatricalPerformancesAsync().Result.Count > 0)
        {
            return;
        }

        var ratings = repository.GetRatingsAsync().Result;

        _ = repository.AddTheatricalPerformanceAsync(new TheatricalPerformance
        {
            Title = "Wicked",
            WatchedDate = DateTime.Parse("2017-08-15"),
            Rating = ratings.Single(x => x.Name == "Good")
        }).Result;

        _ = repository.AddTheatricalPerformanceAsync(new TheatricalPerformance
        {
            Title = "The Phantom of the Opera",
            WatchedDate = DateTime.Parse("2018-09-03"),
            Rating = ratings.Single(x => x.Name == "Disappointing")
        }).Result;

        _ = repository.AddTheatricalPerformanceAsync(new TheatricalPerformance
        {
            Title = "Les Misérables",
            WatchedDate = DateTime.Parse("2019-01-25"),
            Rating = ratings.Single(x => x.Name == "Excellent")
        }).Result;

        _ = repository.AddTheatricalPerformanceAsync(new TheatricalPerformance
        {
            Title = "Frozen the Musical",
            WatchedDate = DateTime.Parse("2019-10-17"),
            Rating = ratings.Single(x => x.Name == "Awful")
        }).Result;

        _ = repository.AddTheatricalPerformanceAsync(new TheatricalPerformance
        {
            Title = "Matilda the Musical",
            WatchedDate = DateTime.Parse("2024-04-21"),
            Rating = ratings.Single(x => x.Name == "Great")
        }).Result;
    }

    #endregion
}
