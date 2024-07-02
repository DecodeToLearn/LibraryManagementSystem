using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class BookDetailsWithAllRelationsDto
    {
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime YearOfPublication { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string CategoryName { get; set; }
    public string CategoryImageUrl { get; set; }
    public string BookImageUrl { get; set; }
    public string PublisherName { get; set; }
    public string PublisherImageUrl { get; set; }
    public string TranslatorFirstName { get; set; }
    public string TranslatorLastName { get; set; }
    public string TranslatorImageUrl { get; set; }
    public DateTime? LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string DescriptionContent { get; set; } 
    }
}