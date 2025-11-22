using Microsoft.EntityFrameworkCore;
using LibraryApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using LibraryApi.Data;
using LibraryApi.Repositories.Interface;
using LibraryApi.Model;
namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryApiDbContext _context;

        public AuthorsController(LibraryApiDbContext context) 
        {
        _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()

        {
           var Authors = _context.Authors.GetAllAuthors();
            return _context.Authors.ToList();

        }
        [HttpGet]
        public Author? GetAuthorById(Guid id)

        {

            return _context.Authors.FirstOrDefault(a => a.Id == id);

        }

        [HttpPost]
        public void AddAuthor(Author author)

        {

            _context.Authors.Add(author);

            _context.SaveChanges();

        }


        [HttpPatch]
        public void UpdateAuthor(Author author)

        {

            _context.Authors.Update(author);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteAuthor(Guid id)

        {

            var author = _context.Authors.FirstOrDefault(a => a.Id == id);

            if (author != null)

            {

                _context.Authors.Remove(author);

                _context.SaveChanges();

            }

        }

    }
}
