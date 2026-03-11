using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Core;

public class Loan
{
    public int Id { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }

    
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;
}