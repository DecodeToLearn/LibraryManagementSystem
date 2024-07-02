using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfStart { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}