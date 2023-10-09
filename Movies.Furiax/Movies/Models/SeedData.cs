using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Movies.Data;

namespace Movies.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new MoviesContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesContext>>())) 
            {
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange
                    (new Movie
                    {
                        Title = "The Nun II",
                        ReleaseDate = DateTime.Parse("2023-09-13"),
                        Genre = "Horror",
                        Price = 21.99M
                    },
                    new Movie{
                    Title = "The Equilizer 3",
                        ReleaseDate = DateTime.Parse("2023-09-1"),
                        Genre = "Action",
                        Price = 24.99M
                    },
                    new Movie
                    {
                        Title = "Mission Impossible - Dead Reckoning Part One",
                        ReleaseDate = DateTime.Parse("2023-07-12"),
                        Genre = "Action",
                        Price = 19.99M
                    },
                    new Movie
                    {
                        Title = "Gran Turismo",
                        ReleaseDate = DateTime.Parse("2023-08-11"),
                        Genre = "Action",
                        Price = 20.99M
                    },
                    new Movie
                    {
                        Title = "Barbie",
                        ReleaseDate = DateTime.Parse("2023-07-21"),
                        Genre = "Comedy",
                        Price = 19.99M
                    },
                    new Movie
                    {
                        Title = "Indiana Jones and the Dial of Destiny",
                        ReleaseDate = DateTime.Parse("2023-06-30"),
                        Genre = "Adventure",
                        Price = 21.99M
                    },
                    new Movie
                    {
                        Title = "No One Will Save You",
                        ReleaseDate = DateTime.Parse("2023-09-22"),
                        Genre = "Horror",
                        Price = 14.99M
                    });
                context.SaveChanges();
            }
        }
    }
}
