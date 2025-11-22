using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
    
    namespace LibraryApi.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
