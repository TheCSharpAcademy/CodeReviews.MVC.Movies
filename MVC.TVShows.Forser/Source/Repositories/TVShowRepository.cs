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
        public async Task UpdateTvShow(TVShow tvShow, List<SelectListItem>? allGenres)
        {
            AssignGenresToTVShow(tvShow, allGenres);

            var existingRecords = await _context.TVShowGenres.ToListAsync();

            foreach (var update in tvShow.TVShow_Genres)
            {
                var existingRecord = existingRecords.FirstOrDefault(sg => sg.TVShow_Id == update.TVShow_Id && sg.Genre_Id == update.Genre_Id);

                if (existingRecord != null)
                {
                    foreach (var genre in allGenres)
                    {
                        if (existingRecord.Genre_Id == Convert.ToInt32(genre.Value) && !genre.Selected)
                        {
                            existingRecords.Remove(existingRecord);
                        }
                    }
                }
                else
                {
                    var newRecord = new TVShow_Genre { TVShow_Id = update.TVShow_Id, Genre_Id = update.Genre_Id };
                    existingRecords.Add(newRecord);
                }
            }

            tvShow.TVShow_Genres = existingRecords;

            await _context.SaveChangesAsync();
        }
    }
}