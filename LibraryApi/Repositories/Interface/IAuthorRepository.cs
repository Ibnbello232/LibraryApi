using LibraryApi.Model;
using System.Collections.Generic;
    
    
    namespace LibraryApi.Repositories.Interface
{
    public interface IAuthorRepository
    {
        IEnumerable<Author>GetAllAuthors();
         Author? GetAuthorById(Guid Id);
         void AddAuthor(Author author);

        void UpdateAuthor(Author author);

        void DeleteAuthor(Guid Id);
    }
}
