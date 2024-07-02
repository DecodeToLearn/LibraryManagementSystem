using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.UnitOfWork;
using LibraryManagementSystem.Services.Abstract;

namespace LibraryManagementSystem.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _unitOfWork.Authors.AddAsync(author);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _unitOfWork.Authors.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthorsWithBooksAsync()
        {
            var authors = await _unitOfWork.Authors.GetAuthorsWithBooksAsync();
            return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        }

        public async Task<AuthorDTO> UpdateAuthorAsync(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _unitOfWork.Authors.UpdateAsync(author);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<AuthorDTO>(author);
        }
    }
}