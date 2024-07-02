using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; } // Kitap başlığını göstermek için
        public List<NoteDto> Notes { get; set; } // Loan ile ilişkili notlar
    }

}