using LibraryApi.Model;

namespace LibraryApi.Repositories.Interface
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre? GetGenreById(Guid Id);
        void AddGenre(Genre genre);

        void UpdateGenre(Genre genre);

        void DeleteGenre(Guid Id);
    }
}
