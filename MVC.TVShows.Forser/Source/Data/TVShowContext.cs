namespace MVC.TVShows.Forser.Data
{
    public class TVShowContext : DbContext
    {
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TVShow_Genre> TVShowGenres { get; set; }
        public TVShowContext(DbContextOptions<TVShowContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TVShow>()
                .HasMany(e => e.Genres)
                .WithOne(e => e.TVShow)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.TVShow_Id);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.TVShow_Genre)
                .WithOne(e => e.Genre)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.Genre_Id);

            modelBuilder.Entity<TVShow>()
                .HasMany(e => e.Ratings)
                .WithOne(e => e.TVShow)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.TVShow_Id);

            modelBuilder.Entity<Rating>()
                .HasMany(e => e.TVShow_Rating)
                .WithOne(e => e.Rating)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.Rating_Id);

            modelBuilder.Entity<Genre>()
                .HasData(
                new Genre { Id = 1, ShowGenre = "Action Comedy" },
                new Genre { Id = 2, ShowGenre = "Adult Chat" },
                new Genre { Id = 3, ShowGenre = "Animated Series" },
                new Genre { Id = 4, ShowGenre = "Animated Sitcom" },
                new Genre { Id = 5, ShowGenre = "Anthology Series" },
                new Genre { Id = 6, ShowGenre = "Apocalyptic and Post-Apocalyptic Fiction" },
                new Genre { Id = 7, ShowGenre = "Archive Television Program" },
                new Genre { Id = 8, ShowGenre = "Breakfast Television" },
                new Genre { Id = 9, ShowGenre = "Casting Television" },
                new Genre { Id = 10, ShowGenre = "Children's Television Series" },
                new Genre { Id = 11, ShowGenre = "Chopshocky" },
                new Genre { Id = 12, ShowGenre = "Comedy Drama" },
                new Genre { Id = 13, ShowGenre = "Cooking Show" },
                new Genre { Id = 14, ShowGenre = "Court Show" }
                );

            modelBuilder.Entity<Rating>()
                .HasData(
                new Rating { Id = 1, Certification = "TV-Y", Description = "This program is designed to be appropriate for all children.", Country = "USA" },
                new Rating { Id = 2, Certification = "TV-Y7", Description = "This program is designed for children age 7 and above.", Country = "USA" },
                new Rating { Id = 3, Certification = "TV-G", Description = "Most parents will find this program suitable for all ages.", Country = "USA" }
                );
        }
    }
}