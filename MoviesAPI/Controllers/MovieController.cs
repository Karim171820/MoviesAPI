using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm]MovieDto dto)
        {
            using var DataStream = new MemoryStream();
            var movie = new Movie
            {
                GenreId = dto.GenreId,
                storyline = dto.storyline,
                Poster = DataStream.ToArray(),
                Rate = dto.Rate,
                Title = dto.Title
            };
           await _context.AddAsync(movie);
            _context.SaveChanges();
            return Ok(movie);

        }

    }
}
