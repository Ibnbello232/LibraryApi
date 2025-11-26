using Microsoft.EntityFrameworkCore;
using LibraryApi.Model;
    namespace LibraryApi.Data

{
    public class LibraryApiDbContext : DbContext
    {
        public LibraryApiDbContext(DbContextOptions<LibraryApiDbContext> options) : base(options)
        {
        }

       public DbSet<Author>Authors { get; set; }
       public DbSet<Book> Books { get; set; }

       public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Author>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(g => !g.IsDeleted);
        }

    }
}
