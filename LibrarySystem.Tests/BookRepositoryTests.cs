using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Core;
using Xunit;

namespace LibrarySystem.Tests
{
    public class BookRepositoryTests
    {
        private LibraryContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;
            return new LibraryContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldSaveBookToDatabase()
        {
           
            using var context = GetDbContext();
            var repository = new BookRepository(context);
            var book = new Book { ISBN = "123", Title = "Test", Author = "Omar", PublishedYear = 2024 };

         
            await repository.AddAsync(book);

          
            var savedBook = await context.Books.FirstOrDefaultAsync(b => b.ISBN == "123");
            Assert.NotNull(savedBook);
            Assert.Equal("Test", savedBook.Title);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllBooks()
        {
            
            using var context = GetDbContext();
            context.Books.Add(new Book { ISBN = "1", Title = "Bok A", Author = "X" });
            context.Books.Add(new Book { ISBN = "2", Title = "Bok B", Author = "Y" });
            await context.SaveChangesAsync();
            var repository = new BookRepository(context);

            
            var result = await repository.GetAllAsync();

            
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SearchAsync_ShouldFindBooksByTitle()
        {
           
            using var context = GetDbContext();
            context.Books.Add(new Book { ISBN = "111", Title = "C# Program", Author = "Omar" });
            await context.SaveChangesAsync();
            var repository = new BookRepository(context);

           
            var result = await repository.SearchAsync("C#");

            
            Assert.Single(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveBook()
        {
            
            using var context = GetDbContext();
            var book = new Book { Id = 1, ISBN = "999", Title = "Tabort", Author = "X" };
            context.Books.Add(book);
            await context.SaveChangesAsync();
            var repository = new BookRepository(context);

           
            await repository.DeleteAsync(1);

            
            var deletedBook = await context.Books.FindAsync(1);
            Assert.Null(deletedBook);
        }
    }
}