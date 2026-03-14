using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.Core;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "ISBN måste fyllas i")]
    public string ISBN { get; set; } = string.Empty;

    [Required(ErrorMessage = "Titel saknas")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Författare måste anges")]
    public string Author { get; set; } = string.Empty;

    [Range(1000, 2026, ErrorMessage = "Ogiltigt årtal")]
    public int PublishedYear { get; set; }

    public bool IsAvailable { get; set; } = true;
    
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
