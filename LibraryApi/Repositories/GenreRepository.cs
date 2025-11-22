using LibraryApi.Data;
using LibraryApi.Model;
using LibraryApi.Repositories.Interface;

namespace LibraryApi.Repositories
{
    public class GenreRepository : IGenreRepository
    {

        private readonly LibraryApiDbContext _context;
        public GenreRepository(LibraryApiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()

        {

            return _context.Genres.ToList();

        }

        public Genre? GetGenreById(Guid id)

        {

            return _context.Genres.FirstOrDefault(a => a.Id == id);

        }

        public void AddGenre(Genre genre)

        {

            _context.Genres.Add(genre);

            _context.SaveChanges();

        }

        public void UpdateGenre(Genre genre)

        {

            _context.Genres.Update(genre);

            _context.SaveChanges();

        }

        public void DeleteGenre(Guid id)

        {

            var genre = _context.Genres.FirstOrDefault(a => a.Id == id);

            if (genre!= null)

            {

                _context.Genres.Remove(genre);

                _context.SaveChanges();

            }

        }

        
    }
}
