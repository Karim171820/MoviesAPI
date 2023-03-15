using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos
{
    public class MovieDto
    {
        [MaxLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }
        [MaxLength(500)]
        public string storyline { get; set; }
        public IFormFile Poster { get; set; }
        public byte GenreId { get; set; }
    }
}
