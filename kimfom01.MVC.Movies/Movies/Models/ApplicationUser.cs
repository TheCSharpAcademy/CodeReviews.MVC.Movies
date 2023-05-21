using Microsoft.AspNetCore.Identity;

namespace Movies.Models;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public IEnumerable<LikedMovie>? LikedMovies { get; set; }
}
