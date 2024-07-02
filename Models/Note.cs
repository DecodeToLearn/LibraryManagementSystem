using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int RegisterId { get; set; }
        public Register Register { get; set; }
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}