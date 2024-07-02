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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookDTO> AddBookAsync(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<BookDTO>(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _unitOfWork.Books.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<IEnumerable<BookWithAuthorDto>> GetBooksWithAuthorsAsync()
        {
            var booksWithAuthors = await _unitOfWork.Books.GetBooksWithAuthorsAsync();
            return _mapper.Map<IEnumerable<BookWithAuthorDto>>(booksWithAuthors);
        }

        public async Task<BookDetailsWithAllRelationsDto> GetBookWithDetailsAsync(int id)
        {
            var book = await _unitOfWork.Books.GetBookWithDetailsAsync(id);
            return _mapper.Map<BookDetailsWithAllRelationsDto>(book);

        }

        public async Task<BookDTO> UpdateBookAsync(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<BookDTO>(book);
        }
    }
}