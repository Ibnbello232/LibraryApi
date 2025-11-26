using LibraryApi.Model;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class AuthorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    }

}