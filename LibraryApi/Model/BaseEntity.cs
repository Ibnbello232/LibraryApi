using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
    
    namespace LibraryApi.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; internal set; }
    }
}
