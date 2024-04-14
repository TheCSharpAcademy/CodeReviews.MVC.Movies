using Microsoft.EntityFrameworkCore;
using Movie.Data;

namespace Movie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MovieContext>>());

        // Look for any movies.
        if (context.Movies.Any())
        {
            return;   // DB has been seeded
        }
        context.Movies.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Rating = "R",
                Price = 7.99M,
                Image = "https://upload.wikimedia.org/wikipedia/en/1/1c/WhenHarryMetSallyPoster.jpg"
            },
            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Rating = "S",
                Price = 8.99M,
                Image = "https://upload.wikimedia.org/wikipedia/en/2/2f/Ghostbusters_%281984%29_theatrical_poster.png"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Rating = "G",
                Price = 9.99M,
                Image = "https://upload.wikimedia.org/wikipedia/en/2/2f/Ghostbusters_%281984%29_theatrical_poster.png"
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Rating = "PG-13",
                Price = 3.99M,
                Image = "https://upload.wikimedia.org/wikipedia/commons/d/de/Dean_Martin_-_Rio_Bravo_1959.jpg"
            }
        );
        context.SaveChanges();
    }
}