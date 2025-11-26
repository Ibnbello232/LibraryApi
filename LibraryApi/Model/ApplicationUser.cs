using Microsoft.AspNetCore.Identity;

namespace LibraryApi.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
