using WatchedList.Domain.Entities;

namespace WatchedList.Web.Models;

/// <summary>
/// Represents the model used to display a rating object in the web application layer.
/// </summary>
public class RatingDto
{
    #region Constructors

    public RatingDto()
    {

    }

    public RatingDto(Rating entity)
    {
        Id = entity.Id;
        Name = entity.Name;
    }

    #endregion
    #region Properties

    public int Id { get; set; }

    public string Name { get; set; }

    public List<MovieDto> Movies { get; set; }
    public List<TvShowDto> TvShows { get; set; }
    public List<TheatricalPerformanceDto> TheatricalPerformances { get; set; }

    #endregion
    #region Methods

    public Rating MapToDomain()
    {
        return new Rating
        {
            Id = this.Id,
            Name = this.Name,
        };
    }

    #endregion
}
