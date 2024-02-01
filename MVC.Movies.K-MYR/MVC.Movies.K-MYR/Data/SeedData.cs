using MVC.Movies.K_MYR.Models;

namespace MVC.Movies.K_MYR.Data;

public static class SeedData
{
    public static void Initialize(DatabaseContext context)
    {
        if (!context.Movies.Any())
        {
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
                    Title = "Ghostbusters ",
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
        }

        if (!context.TVShows.Any())
        {
            context.TVShows.AddRange(
            new TVShow
            {
                Title = "Breaking Bad",
                Seasons = 5,
                ReleaseDate = DateTime.Parse("2010-8-10"),
                Genre = "Drama",
                Price = 5.99M,
                Rating = "TV-14"
            },
            new TVShow
            {
                Title = "Band of Brothers",
                Seasons = 1,
                ReleaseDate = DateTime.Parse("2001-8-5"),
                Genre = "Drama/History/War",
                Price = 9.99M,
                Rating = "TV-MA"
            });
        }

        context.SaveChanges();
    }
}
