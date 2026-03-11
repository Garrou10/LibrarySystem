using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core;
namespace LibrarySystem.Data;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    // Här skickar vi in databas-motorn
    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book?> GetByISBNAsync(string isbn)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync(); // Sparar till databasen
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await GetByIdAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Book>> SearchAsync(string searchTerm)
    {
        
        return await _context.Books
            .Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm))
            .ToListAsync();
    }
}