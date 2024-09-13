namespace WatchedList.Domain.Entities;

/// <summary>
/// Represents a Theatrical Performance entity in the domain layer.
/// </summary>
public class TheatricalPerformance
{
    #region Properties

    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime WatchedDate { get; set; }

    public Rating Rating { get; set; }

    #endregion
}
