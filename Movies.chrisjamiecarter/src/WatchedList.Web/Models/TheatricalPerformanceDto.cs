using System.ComponentModel.DataAnnotations;
using WatchedList.Domain.Entities;

namespace WatchedList.Web.Models;

/// <summary>
/// Represents the model used to display a theatrical performance object in the web application layer.
/// </summary>
public class TheatricalPerformanceDto
{
    #region Constructors

    public TheatricalPerformanceDto()
    {

    }

    public TheatricalPerformanceDto(TheatricalPerformance entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        WatchedDate = entity.WatchedDate;
        RatingId = entity.Rating.Id;
        Rating = new RatingDto(entity.Rating);
    }

    #endregion
    #region Properties

    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [DataType(DataType.Date), Display(Name = "Watched"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime WatchedDate { get; set; }

    public int RatingId { get; set; }

    public RatingDto? Rating { get; set; }

    #endregion
    #region Methods

    public TheatricalPerformance MapToDomain()
    {
        return new TheatricalPerformance
        {
            Id = this.Id,
            Title = this.Title,
            WatchedDate = this.WatchedDate,
            Rating = this.Rating!.MapToDomain()
        };
    }

    #endregion
}
