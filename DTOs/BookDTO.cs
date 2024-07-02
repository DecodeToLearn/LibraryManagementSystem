using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Edition { get; set; }
        public int CategoryId { get; set; } // N TO 1 RELATIONS
        public int PublisherId { get; set; } // N TO 1 RELATIONS
        public int DescriptionId { get; set; } // N TO 1 RELATIONS
        public ICollection<int> AuthorIds { get; set; } // N TO N RELATIONS
        public ICollection<int> TranslatorIds { get; set; } // N TO N RELATIONS
        public ICollection<int> ImageIds { get; set; } // N TO N RELATIONS
    }
}