namespace WatchedList.Domain.Entities;

/// <summary>
/// Represents a TV Show entity in the domain layer.
/// </summary>
public class TvShow
{
    #region Properties

    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime WatchedDate { get; set; }

    public Rating Rating { get; set; }

    #endregion
}
