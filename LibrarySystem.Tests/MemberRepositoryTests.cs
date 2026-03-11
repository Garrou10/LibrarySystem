using Microsoft.EntityFrameworkCore;
using LibrarySystem.Data;
using LibrarySystem.Core;
using Xunit;

namespace LibrarySystem.Tests
{
    public class MemberRepositoryTests
    {
        private LibraryContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new LibraryContext(options);
        }

        [Fact]
        public async Task AddMember_ShouldSaveToDatabase()
        {
            using var context = GetDbContext();
            var member = new Member { FirstName = "Omar" , LastName = "Testsson", Email = "omar@test.com" };
            context.Members.Add(member);
            await context.SaveChangesAsync();

            var savedMember = await context.Members.FirstOrDefaultAsync(m => m.FirstName == "Omar");
            Assert.NotNull(savedMember);
        }

        [Fact]
        public async Task GetAllMembers_ShouldReturnCorrectCount()
        {
            using var context = GetDbContext();
            context.Members.Add(new Member { FirstName = "Ali", LastName = "Abbass", Email = "ali@test.com" });
            context.Members.Add(new Member { FirstName = "Sara", LastName = "Svensson", Email = "sara@test.com" });
            await context.SaveChangesAsync();

            var count = await context.Members.CountAsync();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task SearchMember_ShouldFindByFirstName()
        {
            using var context = GetDbContext();
            context.Members.Add(new Member { FirstName = "Omar", LastName = "Test", Email = "o@test.com" });
            await context.SaveChangesAsync();

            var result = await context.Members.Where(m => m.FirstName.Contains("Omar")).ToListAsync();
            Assert.Single(result);
        }

        [Fact]
        public async Task DeleteMember_ShouldRemoveFromDatabase()
        {
            using var context = GetDbContext();
            var member = new Member { Id = 100, FirstName = "SkaBort", LastName = "Test", Email = "bort@test.com" };
            context.Members.Add(member);
            await context.SaveChangesAsync();

            context.Members.Remove(member);
            await context.SaveChangesAsync();

            var deleted = await context.Members.FindAsync(100);
            Assert.Null(deleted);
        }
    }
}