namespace WatchedList.Infrastructure.Models;

/// <summary>
/// Represents a Theatrical Performance entity in the infrastructure layer.
/// This class is designed to map data from the database, including the theatrical's title, 
/// the date it was watched, and its associated rating.
/// </summary>
internal class TheatricalPerformance
{
    #region Properties

    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public DateTime WatchedDate { get; set; }

    public int RatingId { get; set; }

    public Rating? Rating { get; set; }

    #endregion
    #region Methods

    public Domain.Entities.TheatricalPerformance MapToDomain()
    {
        return new Domain.Entities.TheatricalPerformance
        {
            Id = this.Id,
            Title = this.Title,
            WatchedDate = this.WatchedDate,
            Rating = this.Rating!.MapToDomain()
        };
    }

    #endregion
}
