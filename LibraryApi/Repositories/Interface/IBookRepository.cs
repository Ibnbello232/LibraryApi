using LibraryApi.Model;
using LibraryApi.Repositories.Interfaces;



namespace LibraryApi.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> SearchAsync(string keyword);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
        Task<IEnumerable<Book>> GetPagedBooksAsync(int page, int pageSize);
    }
}