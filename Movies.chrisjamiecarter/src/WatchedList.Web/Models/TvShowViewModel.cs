using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WatchedList.Web.Models;

/// <summary>
/// Represents the view model used to display a list of tv show objects in the web application layer.
/// </summary>
public class TvShowViewModel
{
    #region Properties

    public List<TvShowDto>? TvShows { get; set; }

    public SelectList? Ratings { get; set; }

    public RatingDto? Rating { get; set; }

    public int? RatingId { get; set; }

    [Display(Name = "Search")]
    public string? SearchString { get; set; }

    public string? CurrentSort { get; set; }

    public string? TitleSort { get; set; }

    public string? WatchDateSort { get; set; }

    public string? RatingSort { get; set; }

    #endregion
}
