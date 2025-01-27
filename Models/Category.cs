using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? DescriptionId { get; set; }
        public Description Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}