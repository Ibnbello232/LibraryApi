using LibraryApi.Repositories.Interface;
using LibraryApi.Data;
using LibraryApi.Model;

namespace LibraryApi.Repositories.Implementations
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryApiDbContext context) : base(context) { }
    }
}