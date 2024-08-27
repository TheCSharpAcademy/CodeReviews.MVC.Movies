namespace WatchedList.Web.Models;

/// <summary>
/// Represents the model used to display error information in the web application layer.
/// </summary>
public class ErrorViewModel
{
    #region Properties

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    #endregion
}
