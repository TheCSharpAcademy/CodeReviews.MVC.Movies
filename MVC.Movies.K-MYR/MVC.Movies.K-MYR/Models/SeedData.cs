using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Data;

namespace MVC.Movies.K_MYR.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>());
        if (context.Movies.Any())
            return;

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
        context.SaveChanges();
    }
}
