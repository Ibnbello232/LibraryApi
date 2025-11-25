using LibraryApi.Model;
using System.ComponentModel.DataAnnotations;
    
    namespace LibraryApi.DTO
{
    public class BookCreateDTO : BaseEntity
    {
        [Required ,MaxLength (200)]
        public string Title { get; set; } = string.Empty;

        [Required , MaxLength(13)]
        public string ISBN { get; set; } = string.Empty;

        [Required]
        public int PublicationYear { get; set; }
    }
     
    public  class BooKUpdateDTO : BookCreateDTO { }
    public class BookReadDTO : BaseEntity
    {
       
       public string title { get; set; } = string.Empty;
        public string ISBN { get; set;} = string.Empty;

        public int PublicationYear { get; set; }
        
        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public string GenreName { get; set;} = string.Empty;


    }
}
