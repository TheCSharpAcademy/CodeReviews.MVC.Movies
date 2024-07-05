using System.ComponentModel.DataAnnotations;

namespace MovieManager.People.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; } = "";
        public string? Thumbnail { get; set; } = "";
    }
}
