using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {

        }
        public async Task<IEnumerable<BookWithAuthorDto>> GetBooksWithAuthorsAsync()
        {
            var query = from b in _context.Books
                        join ba in _context.BookAuthors on b.Id equals ba.BookId
                        join a in _context.Authors on ba.AuthorId equals a.Id
                        select new BookWithAuthorDto
                        {
                            Title = b.Title,
                            ISBN = b.ISBN,
                            Price = b.Price,
                            Stock = b.Stock,
                            YearOfPublication = b.YearOfPublication,
                            FirstName = a.FirstName,
                            LastName = a.LastName
                        };

            return await query.ToListAsync();
        }

        public async Task<BookDetailsWithAllRelationsDto> GetBookWithDetailsAsync(int id)
        {
            var query = from b in _context.Books
                        join ba in _context.BookAuthors on b.Id equals ba.BookId
                        join a in _context.Authors on ba.AuthorId equals a.Id
                        join c in _context.Categories on b.CategoryId equals c.Id
                        join i in _context.Images on b.Id equals i.BookId
                        join p in _context.Publishers on b.PublisherId equals p.Id
                        join bt in _context.BookTranslators on b.Id equals bt.BookId
                        join t in _context.Translators on bt.TranslatorId equals t.Id
                        join l in _context.Loans on b.Id equals l.BookId
                        join d in _context.Descriptions on b.Id equals d.BookId
                        where b.Id == id
                        select new BookDetailsWithAllRelationsDto
                        {
                            Title = b.Title,
                            ISBN = b.ISBN,
                            Price = b.Price,
                            Stock = b.Stock,
                            YearOfPublication = b.YearOfPublication,
                            AuthorFirstName = a.FirstName,
                            AuthorLastName = a.LastName,
                            CategoryName = c.Name,
                            CategoryImageUrl = c.ImageUrl,
                            BookImageUrl = i.Url,
                            PublisherName = p.Name,
                            PublisherImageUrl = p.ImageUrl,
                            TranslatorFirstName = t.FirstName,
                            TranslatorLastName = t.LastName,
                            TranslatorImageUrl = t.ImageUrl,
                            LoanDate = l.LoanDate,
                            ReturnDate = l.ReturnDate,
                            DescriptionContent = d.Content
                        };
            return await query.FirstOrDefaultAsync();
        }
    }
}