using Microsoft.EntityFrameworkCore;
using Movies.wkktoria.Models;

namespace Movies.wkktoria.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AppDbContext>>());

        if (context.Movies == null) return;

        // Look for any movies.
        if (context.Movies.Any()) return; // DB has been seeded

        context.Movies.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Ghostbusters",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M,
                Rating = "R"
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M,
                Rating = "R"
            }
        );

        if (context.Albums == null) return;

        // Look for any albums.
        if (context.Albums.Any()) return; // DB has been seeded

        context.Albums.AddRange(
            new Album
            {
                CoverPath = "https://upload.wikimedia.org/wikipedia/en/2/20/Coma_-_Pierwsze_wyj%C5%9Bcie_z_mroku.jpg",
                Artist = "Coma",
                Title = "Pierwsze wyjście z mroku",
                ReleaseDate = DateTime.Parse("2004-05-17"),
                Genre = "Rock"
            },
            new Album
            {
                CoverPath = "https://upload.wikimedia.org/wikipedia/en/a/a3/Deathcrush.jpg",
                Artist = "Mayhem",
                Title = "Deathcrush",
                ReleaseDate = DateTime.Parse("1987-08-16"),
                Genre = "Black metal"
            }
        );

        context.SaveChanges();
    }
}