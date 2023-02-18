namespace Movies.DataAccessLibrary.Models;

public class MovieDbDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public double Rating { get; set; }
    public required string Genre { get; set; }
    public int Year { get; set; }
    public required string Description { get; set; }
}