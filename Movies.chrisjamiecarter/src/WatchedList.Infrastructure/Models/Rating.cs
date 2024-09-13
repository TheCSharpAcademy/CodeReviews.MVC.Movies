namespace WatchedList.Infrastructure.Models;

/// <summary>
/// Represents a Rating entity in the infrastructure layer.
/// This class is designed to map data from the database, including the rating name 
/// and its associations with movies, TV shows, and theatrical performances.
/// </summary>
internal class Rating
{
    #region Properties

    public int Id { get; set; }

    public string Name { get; set; } = "";

    public List<Movie>? Movies { get; set; }

    public List<TvShow>? TvShows { get; set; }

    public List<TheatricalPerformance>? TheatricalPerformances { get; set; }

    #endregion
    #region Methods

    public Domain.Entities.Rating MapToDomain()
    {
        return new Domain.Entities.Rating
        {
            Id = this.Id,
            Name = this.Name,
        };
    }

    #endregion
}
