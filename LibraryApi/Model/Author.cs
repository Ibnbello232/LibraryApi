using System.ComponentModel.DataAnnotations; 
    
    namespace LibraryApi.Model
{
    public class Author : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Bio {  get; set; } = string.Empty;
        [Required]
        public int DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }

    
}
