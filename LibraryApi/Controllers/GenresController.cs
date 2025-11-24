using Microsoft.EntityFrameworkCore;
using LibraryApi.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using LibraryApi.Data;
using LibraryApi.Repositories.Interface;
using LibraryApi.Model;
using System;


namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GenresController(LibraryApiDbContext context) : ControllerBase
    {
        private readonly LibraryApiDbContext _context = context;
        private Genre genre;

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetAllGenres()

        {

            return _context.Genres.ToList();

        }

        [HttpGet]
        public Genre? GetGenreById(Guid id)

        {
            return _context.Genres.FirstOrDefault(a => a.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> AddGenre(Genre genre)

        {
            _context.Genres.Add(genre);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id });

        }

        [HttpPatch]
        public void UpdateGenre(Genre Genre)

        {

            _context.Genres.Update(genre);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteGenre(Guid id)

        {

            var genre = _context.Genres.FirstOrDefault(a => a.Id == id);

            if (genre != null)

            {

                _context.Genres.Remove(genre);

                _context.SaveChanges();

            }
        }
    }
}
