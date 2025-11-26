using LibraryApi.Data;
using LibraryApi.DTO;
using LibraryApi.Model;
using LibraryApi.Repositories;
using LibraryApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepo;

        public GenresController(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _genreRepo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            return genre == null ? NotFound() : Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GenreDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var genre = new Genre
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _genreRepo.AddAsync(genre);
            await _genreRepo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = genre.Id }, genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] GenreDto dto)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            if (genre == null) return NotFound();

            genre.Name = dto.Name;
            genre.Description = dto.Description;

            _genreRepo.Update(genre);
            await _genreRepo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genreRepo.GetByIdAsync(id);
            if (genre == null) return NotFound();

            _genreRepo.Delete(genre);
            await _genreRepo.SaveAsync();

            return NoContent();
        }
    }
}
