using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core;

namespace LibrarySystem.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        if (!options.IsConfigured)
        {
            options.UseSqlite("Data Source=library.db");
        }
    }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }
}