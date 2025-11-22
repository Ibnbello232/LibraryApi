using System.ComponentModel.DataAnnotations;
    
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

    }
}
