using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Edition { get; set; }
        public DateTime YearOfPublication { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int? DescriptionId { get; set; }
        public Description Description { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookTranslator> BookTranslators { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}