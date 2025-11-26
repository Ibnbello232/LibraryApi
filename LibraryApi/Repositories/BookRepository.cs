using LibraryApi.Repositories;
using LibraryApi.Repositories.Interface;
using LibraryApi.Data;
using LibraryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private new readonly LibraryApiDbContext _context;

        public BookRepository(LibraryApiDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }

        public override async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string keyword)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b =>
                    b.Title.Contains(keyword) ||
                    b.Author.FirstName.Contains(keyword) ||
                    b.Author.LastName.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId)
        {
            return await _context.Books
                .Include(b => b.Genre)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetPagedBooksAsync(int page, int pageSize)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}