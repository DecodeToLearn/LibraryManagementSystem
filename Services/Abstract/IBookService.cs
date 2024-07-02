using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTOs;

namespace LibraryManagementSystem.Services.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<BookDTO> AddBookAsync(BookDTO bookDto);
        Task<BookDTO> UpdateBookAsync(BookDTO bookDto);
        Task DeleteBookAsync(int id);

        Task<IEnumerable<BookWithAuthorDto>> GetBooksWithAuthorsAsync();
        Task<BookDetailsWithAllRelationsDto> GetBookWithDetailsAsync(int id);
    }
}