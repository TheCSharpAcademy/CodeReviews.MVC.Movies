namespace MVC.TVShows.Forser.Models
{
    public class TVShow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [DisplayName("Show Title")]
        [Required]
        public string Title { get; set; }
        [DisplayName("Show Startdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required]
        public DateTime ShowStarted {  get; set; }
        [DisplayName("Show Enddate")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ShowCompleted { get; set; }
        [DisplayName("Number of Episodes")]
        public int NumberOfEpisodes { get; set; }
        [DisplayName("Number of Seasons")]
        public int NumberOfSeasons { get; set; }
        [DisplayName("Have watched the Show")]
        public bool BeenWatched { get; set; } = false;
        public IEnumerable<TVShow_Rating>? TVShow_Ratings { get; set; }
        public IEnumerable<TVShow_Genre>? TVShow_Genres { get; set; }
    }
}