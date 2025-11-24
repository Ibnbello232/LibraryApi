using LibraryApi.Model;
using LibraryApi.Data;
using LibraryApi.DTO;
using LibraryApi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Controllers
{
    

        [Route("api/[controller]")]

        [ApiController]

        public class BookController : ControllerBase

        {

            private readonly LibraryApiDbContext _context;

            public BookController(LibraryApiDbContext context)

            {

                _context = context;

            }

            

            [HttpGet]

            public async Task<ActionResult<IEnumerable<Book>>> GetBooks()

            {

                return await _context.Books .ToListAsync();

            }

            

            [HttpGet]

            public async Task<ActionResult<Book>> GetBook(Guid id)

            {

                var book = await _context.Books
                    .FirstOrDefaultAsync(b => b.Id == id);

                if (book == null)

                    return NotFound();

                return book;

            }

           

            [HttpPost]

            public async Task<ActionResult<Book>> CreateBook(Book book)

            {

                _context.Books.Add(book);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);

            }

           

            [HttpPut("{id:guid}")]

            public async Task<IActionResult> UpdateBook(Guid id, Book book)

            {

                if (id != book.Id)

                    return BadRequest();

                _context.Entry(book).State = EntityState.Modified;

                try

                {

                    await _context.SaveChangesAsync();

                }

                catch (DbUpdateConcurrencyException)

                {

                    if (!_context.Books.Any(b => b.Id == id))

                        return NotFound();

                    else

                        throw;

                }

                return NoContent();

            }

            // DELETE: api/books/{id}

            [HttpDelete("{id:guid}")]

            public async Task<IActionResult> DeleteBook(Guid id)

            {

                var book = await _context.Books.FindAsync(id);

                if (book == null)

                    return NotFound();

                _context.Books.Remove(book);

                await _context.SaveChangesAsync();

                return NoContent();

            }
        }

    }



