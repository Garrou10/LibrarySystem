using LibrarySystem.Core;
using Xunit;

namespace LibrarySystem.Tests
{
    public class ModelTests
    {
        [Fact]
        public void Book_ShouldStoreTitleCorrectly()
        {
            var book = new Book { Title = "C# Programmering" };
            Assert.Equal("C# Programmering", book.Title);
        }

        [Fact]
        public void Member_ShouldHaveFirstNameSet()
        {
            var member = new Member { FirstName = "Omar" };
            Assert.Equal("Omar", member.FirstName);
        }
    }
}