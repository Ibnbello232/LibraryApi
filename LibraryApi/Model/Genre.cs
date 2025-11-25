using System.ComponentModel.DataAnnotations; 
    
    namespace LibraryApi.Model
{
    public class Genre : BaseEntity
    {
        [Required]
        public string Name {  get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
