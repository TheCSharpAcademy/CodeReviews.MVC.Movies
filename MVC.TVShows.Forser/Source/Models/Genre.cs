﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.TVShows.Forser.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShowGenre { get; set; } = string.Empty;
        public IEnumerable<TVShow_Genre>? TVShow_Genre { get; set; }
    }
}