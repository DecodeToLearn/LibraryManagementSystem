using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DTOs
{
    public class DescriptionDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? TranslatorId { get; set; }
    }
}