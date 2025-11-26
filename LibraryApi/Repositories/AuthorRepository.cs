using LibraryApi.Model;
using LibraryApi.Data;

using LibraryApi.Repositories;
using LibraryApi.Repositories.Interface;

namespace LibraryApi.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryApiDbContext context) : base(context) { }
    }
}