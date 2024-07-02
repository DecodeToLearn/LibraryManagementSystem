using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<BookWithAuthorDto>> GetBooksWithAuthorsAsync();
        Task<BookDetailsWithAllRelationsDto> GetBookWithDetailsAsync(int id);
    }
}