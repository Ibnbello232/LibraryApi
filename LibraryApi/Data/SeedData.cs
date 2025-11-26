using LibraryApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    
    
        public static class SeedData
        {
            public static async Task InitializeAsync(
                LibraryApiDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager)
            {
                context.Database.Migrate();

                string[] roleNames = { "Admin", "User" };
                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var adminEmail = "admin@library.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FullName = "System Admin"
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123"); // strong password
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }

                if (!context.Authors.Any())
                {
                    var author1 = new Author
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Muhydeen",
                        LastName = "Adediran",
                        Bio = "C# Backend Developer and owner of 'Zentrium'."
                    };

                    var author2 = new Author
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Oluwasegun",
                        LastName = "Adedeji",
                        Bio = "Junior Backend Developer."
                    };

                    context.Authors.AddRange(author1, author2);

                    var genre1 = new Genre
                    {
                        Id = Guid.NewGuid(),
                        Name = "Programming"
                    };

                    var genre2 = new Genre
                    {
                        Id = Guid.NewGuid(),
                        Name = "Coding"
                    };

                    context.Genres.AddRange(genre1, genre2);

                    var book1 = new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "C# Basics",
                        AuthorId = author1.Id,
                        GenreId = genre1.Id,
                        ISBN = "9780199110834"
                    };

                    var book2 = new Book
                    {
                        Id = Guid.NewGuid(),
                        Title = "Coding made simple!",
                        AuthorId = author2.Id,
                        GenreId = genre2.Id,
                        ISBN = "9762788299928"
                    };

                    context.Books.AddRange(book1, book2);

                    await context.SaveChangesAsync();
                }
            }
        }
}

