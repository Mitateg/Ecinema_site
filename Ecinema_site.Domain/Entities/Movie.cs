namespace Ecinema_site.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public double Rating { get; set; }
    }
} 