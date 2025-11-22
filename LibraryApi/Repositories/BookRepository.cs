using LibraryApi.Model;
using LibraryApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System;
using LibraryApi.Data;


namespace LibraryApi.Repositories
{
    public class BookRepository : IBookRepository
    {

            private readonly LibraryApiDbContext _context;
            public BookRepository(LibraryApiDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Book> GetAllBooks()

            {

                return _context.Books.ToList();

            }

            public Book? GetBookById(Guid id)

            {

                return _context.Books.FirstOrDefault(a => a.Id == id);

            }

            public void AddBook(Book book)

            {

                _context.Books.Add(book);

                _context.SaveChanges();

            }

            public void UpdateBook(Book book)

            {

                _context.Books.Update(book);

                _context.SaveChanges();

            }

            public void DeleteBook(Guid id)

            {


                var book = _context.Books.FirstOrDefault(a => a.Id == id);

                if (book != null)
                {

                    _context.Books.Remove(book); 

                    _context.SaveChanges();

                }

            }

       
    }
}
