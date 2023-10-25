namespace MVC.TVShows.Forser.Data
{
    public class TVShowContext : DbContext
    {
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TVShow_Genre> TVShowGenres { get; set; }
        public DbSet<TVShow_Rating> TVShowRatings { get; set; }
        public TVShowContext(DbContextOptions<TVShowContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TVShow_Genre>()
                .HasKey(sg => new { sg.TVShow_Id, sg.Genre_Id });

            modelBuilder.Entity<TVShow_Genre>()
                .HasOne(sg => sg.TVShow)
                .WithMany(s => s.TVShow_Genres)
                .HasForeignKey(sg => sg.TVShow_Id);

            modelBuilder.Entity<TVShow_Genre>()
                .HasOne(sg => sg.Genre)
                .WithMany(s => s.TVShow_Genres)
                .HasForeignKey(sg => sg.Genre_Id);

            modelBuilder.Entity<TVShow_Rating>()
                .HasKey(sg => new { sg.TVShow_Id, sg.Rating_Id });

            modelBuilder.Entity<TVShow_Rating>()
                .HasOne(sg => sg.TVShow)
                .WithOne(s => s.TVShow_Rating)
                .HasForeignKey<TVShow_Rating>(sg => sg.TVShow_Id);

            modelBuilder.Entity<TVShow_Rating>()
                .HasOne(sg => sg.Rating)
                .WithOne(s => s.TVShow_Rating)
                .HasForeignKey<TVShow_Rating>(sg => sg.Rating_Id);

            modelBuilder.Entity<TVShow>()
                .HasMany(s => s.TVShow_Genres)
                .WithOne(sg => sg.TVShow)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.TVShow_Genres)
                .WithOne(sg => sg.Genre)
                .OnDelete(DeleteBehavior.Cascade);

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