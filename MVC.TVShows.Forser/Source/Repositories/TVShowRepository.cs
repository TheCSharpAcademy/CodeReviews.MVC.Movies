namespace MVC.TVShows.Forser.Repositories
{
    public class TVShowRepository : GenericRepository<TVShow>, ITVShowRepository
    {
        private readonly TVShowContext _context;
        public TVShowRepository(TVShowContext context) : base(context) 
        {
            _context = context;
        }
        public TVShow GetTVShowById(int id)
        {
            TVShow tvShow = null;
            try
            {
                tvShow = _context.TVShows
                .Include(g => g.TVShow_Genres)
                .ThenInclude(g => g.Genre)
                .Include(r => r.TVShow_Ratings)
                .ThenInclude(r => r.Rating)
                .OrderBy(i => i.Id)
                .Where(w => w.Id == id)
                .FirstOrDefault();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return tvShow;
        }
        public async Task DeleteTvShow(TVShow tvShow)
        {
            try
            {
                TVShow exists = await _context.TVShows.FindAsync(tvShow.Id);
                _context.Remove(exists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AssignGenresToTVShow(TVShow tvShow, List<SelectListItem> allGenres)
        {
            List<Genre> listOfGenre = GenerateGenreList(allGenres);
            List<TVShow_Genre> tvShow_Genres = new List<TVShow_Genre>();

            foreach (Genre genre in listOfGenre)
            {
                tvShow_Genres.Add(
                    new TVShow_Genre
                    {
                        Genre_Id = genre.Id,
                        TVShow_Id = tvShow.Id
                    }
                );
            }
            tvShow.TVShow_Genres = tvShow_Genres;
        }
        public void AssignRatingToTVShow(TVShow tvShow, int ratingId)
        {
            List<TVShow_Rating> tvShow_Rating = new List<TVShow_Rating>();

            tvShow_Rating.Add(new TVShow_Rating
            {
                Rating_Id = Convert.ToInt32(ratingId),
                TVShow_Id = tvShow.Id
            });

            tvShow.TVShow_Ratings = tvShow_Rating;
        }
        private static List<Genre> GenerateGenreList(List<SelectListItem> selectedGenres)
        {
            List<Genre> generatedGenreList = new List<Genre>();

            var temp = selectedGenres.Where(s => s.Selected == true);

            foreach (var genre in temp)
            {
                generatedGenreList.Add(
                    new Genre
                    {
                        Id = Convert.ToInt32(genre.Value),
                        ShowGenre = genre.Text,
                        Checked = genre.Selected
                    });
            }

            return generatedGenreList;
        }
        public async Task UpdateTvShow(TVShow tvShow, List<SelectListItem>? allGenres, int ratingId)
        {
            AssignGenresToTVShow(tvShow, allGenres);
            AssignRatingToTVShow(tvShow, ratingId);

            var existingGenreRecords = await _context.TVShowGenres.ToListAsync();
            var existingRatingRecords = await _context.TVShowRatings.ToListAsync();

            foreach (var update in tvShow.TVShow_Genres)
            {
                var existingRecord = existingGenreRecords.FirstOrDefault(sg => sg.TVShow_Id == update.TVShow_Id && sg.Genre_Id == update.Genre_Id);

                if (existingRecord != null)
                {
                    foreach (var genre in allGenres)
                    {
                        if (existingRecord.Genre_Id == Convert.ToInt32(genre.Value) && !genre.Selected)
                        {
                            existingGenreRecords.Remove(existingRecord);
                        }
                    }
                }
                else
                {
                    var newRecord = new TVShow_Genre { TVShow_Id = update.TVShow_Id, Genre_Id = update.Genre_Id };
                    existingGenreRecords.Add(newRecord);
                }
            }

            foreach (var update in tvShow.TVShow_Ratings)
            {
                if (update != null)
                {
                    var existingRecord = existingRatingRecords.FirstOrDefault(sg => sg.TVShow_Id == update.TVShow_Id && sg.Rating_Id != ratingId);

                    if (existingRecord != null)
                    {

                        if (existingRecord.Rating_Id != ratingId)
                        {
                            existingRatingRecords.Remove(existingRecord);
                        }
                    }
                    else
                    {
                        var newRecord = new TVShow_Rating() { TVShow_Id = update.TVShow_Id, Rating_Id = ratingId };
                        existingRatingRecords.Add(newRecord);
                    }
                }
            }

            tvShow.TVShow_Genres = existingGenreRecords;
            tvShow.TVShow_Ratings = existingRatingRecords;

            await _context.SaveChangesAsync();
        }
    }
}