using System.ComponentModel.DataAnnotations;

namespace Movies.wkktoria.Models;

public class Movie
{
    [Key] public long Id { get; set; }
}