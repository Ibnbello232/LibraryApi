using LibraryApi.Data;
using LibraryApi.Model;
using LibraryApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System;
    
    namespace LibraryApi.Repositories
{
    public class AuthorRepository : IAuthorRepository 

    {
        
        private readonly LibraryApiDbContext _context;
        public AuthorRepository(LibraryApiDbContext context) 
        {
               _context = context;
        }

        public IEnumerable<Author> GetAllAuthors()

        {

            return _context.Authors.ToList();

        }

        public Author? GetAuthorById(Guid id)

        {

            return _context.Authors.FirstOrDefault(a => a.Id == id);

        }

        public void AddAuthor(Author author)

        {

            _context.Authors.Add(author);

            _context.SaveChanges();

        }

        public void UpdateAuthor(Author author)

        {

            _context.Authors.Update(author);

            _context.SaveChanges();

        }

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
