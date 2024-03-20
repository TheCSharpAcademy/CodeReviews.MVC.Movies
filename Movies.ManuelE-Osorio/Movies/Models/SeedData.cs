using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using System;
using System.Linq;

namespace Movies.Models;

public static class SeedData
{
    public static void InitializeMovies(IServiceProvider serviceProvider)
    {
        using var context = new MovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MovieContext>>());

        context.Database.EnsureCreated();
        if (context.Movie.Any())
        {
            return;
        }
        context.Movie.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Rating = "R",
                Price = 7.99M
            },
            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M
            }
        );
        context.SaveChanges();
    }

    public static void InitializeTvShows(IServiceProvider services)
    {
        using var context = new MovieContext(
            services.GetRequiredService<
                DbContextOptions<MovieContext>>());
        if (context.TvShow.Any())
        {
            return;
        }
        context.TvShow.AddRange(
            new TvShow
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Rating = "R",
                Price = 7.99M
            },
            new TvShow
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M
            },
            new TvShow
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M
            },
            new TvShow
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M
            }
        );
        context.SaveChanges();
    }
}
