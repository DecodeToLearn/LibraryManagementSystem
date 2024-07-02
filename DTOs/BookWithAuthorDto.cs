using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class BookWithAuthorDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime YearOfPublication { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}