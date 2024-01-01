using Microsoft.EntityFrameworkCore;
using MVC.Movies.Speedierone.Data;

namespace MVC.Movies.Speedierone.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMoviesContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMoviesContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(new Movie
                {
                    Title = "Aliens",
                    ReleaseDate = DateTime.Parse("01-01-1989"),
                    Genre = "Sci-fi",
                    Price = 9.99m,
                    Rating = "18"
                },

                new Movie
                {
                    Title = "Gladiators",
                    ReleaseDate = DateTime.Parse("20-06-2006"),
                    Genre = "Action",
                    Price = 2.99m,
                    Rating = "15"
                },

                new Movie
                {
                    Title = "Monster Hunter",
                    ReleaseDate = DateTime.Parse("25-06-2022"),
                    Genre = "Action",
                    Price = 5.99m,
                    Rating = "12"
                });
                context.SaveChanges();
            }
        }
    }
}
