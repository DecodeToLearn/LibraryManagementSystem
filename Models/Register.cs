using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Register
    {
        public int Id { get; set; }  // Primary Key
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Gender { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string? ImageUrl { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Note> Notes { get; set; }
       // public ApplicationUser User { get; set; }
    }
}