using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApi.Model;
    
    namespace LibraryApi.Model
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string ISBN { get; set; } = string.Empty; 
        [Required]
        public int PublicationYear { get; set; }

        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        [ForeignKey("Genre")]

        public Guid GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
        

    }
}
