namespace MovieManager.Movies.Models
{
    public class MovieStarRatingViewModel
    {
        public int NumFullStars { get; set; } = 0;
        public bool HasHalfStar { get; set; } = false;
        public int NumEmptyStars { get; set; } = 0;

        public MovieStarRatingViewModel(decimal? rating)
        {
            if (rating.HasValue)
            {
                NumFullStars = (int)decimal.Floor(rating.Value);
                HasHalfStar = NumFullStars != rating.Value;
                NumEmptyStars = 5 - NumFullStars - (HasHalfStar ? 1 : 0);
            }
        }
    }
}
