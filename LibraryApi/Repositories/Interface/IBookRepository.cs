using LibraryApi.Model;

namespace LibraryApi.Repositories.Interface
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book? GetBookById(Guid Id);
        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(Guid Id);
    }
}
