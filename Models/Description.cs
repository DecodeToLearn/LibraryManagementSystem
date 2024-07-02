using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Description
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int? TranslatorId { get; set; }
        public Translator Translator { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}