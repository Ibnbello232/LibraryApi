using LibraryApi.Model;
using System.ComponentModel.DataAnnotations;
    
    namespace LibraryApi.DTO
{
    public class AuthorCreateDTO : BaseEntity
    {
        [Required , MaxLength (100)]
        public string FirstName { get; set; } = string.Empty;
        [Required , MaxLength (100)]
        public string LastName { get; set; } = string.Empty;
        [Required , MaxLength (600)]
        public string Bio {  get; set; } = string.Empty;
        [Required]
        public int DateOfBirth { get; set; }

    }


    public class AuthorUpdateDTO : AuthorCreateDTO { }
       public class AuthorReadDTO : BaseEntity
    {
    

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;
 
       public int DateOfBirth { get; set; }
    }
}
