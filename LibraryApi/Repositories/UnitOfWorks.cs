using LibraryApi.Repositories.Interfaces;
using LibraryApi.Data;

namespace LibraryApi.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryApiDbContext _context;

        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }
        public IGenreRepository Genres { get; }

        public UnitOfWork(LibraryApiDbContext context,
                          IBookRepository bookRepository,
                          IAuthorRepository authorRepository,
                          IGenreRepository genreRepository)
        {
            _context = context;
            Books = bookRepository;
            Authors = authorRepository;
            Genres = genreRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}