namespace WatchedList.Infrastructure.Models;

/// <summary>
/// Represents a Movie entity in the infrastructure layer.
/// This class is designed to map data from the database, including the movie's title, 
/// the date it was watched, and its associated rating.
/// </summary>
internal class Movie
{
    #region Properties

    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public DateTime WatchedDate { get; set; }

    public int RatingId { get; set; }

    public Rating? Rating { get; set; }

    #endregion
    #region Methods

    public Domain.Entities.Movie MapToDomain()
    {
        return new Domain.Entities.Movie
        {
            Id = this.Id,
            Title = this.Title,
            WatchedDate = this.WatchedDate,
            Rating = this.Rating!.MapToDomain()
        };
    }

    #endregion
}
