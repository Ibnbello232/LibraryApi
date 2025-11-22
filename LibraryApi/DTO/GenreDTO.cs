using LibraryApi.Model;
using System.ComponentModel.DataAnnotations;
    
    namespace LibraryApi.DTO
{
    public class CreateGenreDTO : BaseEntity
    {
        [Required , MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required , MaxLength (500)]
        public string Description { get; set; } = string.Empty;
    }

    public class GenreUpdateDTO :CreateGenreDTO { }
    public class GenreReadDTO : BaseEntity
    {
      
      public string Name { get; set; } = string.Empty;

      public string Description { get; set; } = string.Empty;
    }
}
