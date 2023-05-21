using System.ComponentModel.DataAnnotations;

namespace Movies.Models;

public enum Status
{
    Watched,
    Watching,
    [Display(Name="Will Watch")]
    WillWatch
}