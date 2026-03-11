using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using LibrarySystem.Core;

namespace LibrarySystem.Data;

public class LoanRepository
{
    private readonly LibraryContext _context;

    public LoanRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task CreateLoanAsync(int bookId, int memberId)
    {
        var book = await _context.Books.FindAsync(bookId);
        if (book != null && book.IsAvailable)
        {
            
            book.IsAvailable = false;

            
            var loan = new Loan
            {
                BookId = bookId,
                MemberId = memberId,
                LoanDate = DateTime.Now
            };

            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Loan>> GetActiveLoansAsync()
    {
      
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.Member)
            .Where(l => l.ReturnDate == null)
            .ToListAsync();
    }
}