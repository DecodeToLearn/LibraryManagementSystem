using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTOs;

namespace LibraryManagementSystem.Services.Abstract
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
        Task<AuthorDTO> GetAuthorByIdAsync(int id);
        Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto);
        Task<AuthorDTO> UpdateAuthorAsync(AuthorDTO authorDto);
        Task DeleteAuthorAsync(int id);

        Task<IEnumerable<AuthorDTO>> GetAuthorsWithBooksAsync();
    }
}