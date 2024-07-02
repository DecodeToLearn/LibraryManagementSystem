using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BookTranslator
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int TranslatorId { get; set; }
        public Translator Translator { get; set; }
    }
}