using LibraryApi.Model;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class GenreDto
    {

        [Required]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}