using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Concrete
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Author>> GetAuthorsWithBooksAsync()
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                     .ThenInclude(ba => ba.Book)
                .ToListAsync();
        }
    }
}