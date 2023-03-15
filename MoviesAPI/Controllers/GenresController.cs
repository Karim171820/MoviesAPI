using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var genres = await _context.Genres.ToListAsync();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto dto)
        {
            var genre = new Genre { Name = dto.name };
            await _context.AddAsync(genre);
            _context.SaveChanges();
            return Ok(genre);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> CreateAsync(byte id, CreateGenreDto dto)
        {

            var genre = await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);


            genre.Name = dto.name;
            _context.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genre == null) return NotFound($"There is no genre with this ID : {id}");

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return Ok(genre);
        }
    }
}
    