using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;

namespace RazorPagesBook.Pages.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesBookContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Władca Pierścieni",
                        Genre = "Fantasy",
                        Price = 8.99M,
                         Rating = "S"
                    },

                    new Book
                    {
                        Title = "When Harry Met Sally",
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                         Rating = "A"
                    },

                    new Book
                    {
                        Title = "Pan Lodowego Ogrodu",
                        Genre = "Fantasy",
                        Price = 7.99M,
                         Rating = "A"
                    },

                    new Book
                    {
                        Title = "Przemineło z Wiatrem",
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "A"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
