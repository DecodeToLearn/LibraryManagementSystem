using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Translator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int? DescriptionId { get; set; }
        public Description Description { get; set; }
        public ICollection<BookTranslator> BookTranslators { get; set; }
    }
}