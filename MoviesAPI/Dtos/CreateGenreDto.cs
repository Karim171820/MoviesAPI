using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Dtos
{
    public class CreateGenreDto
    {
        [MaxLength(100)]
        public string name { get; set; }
    }
}
