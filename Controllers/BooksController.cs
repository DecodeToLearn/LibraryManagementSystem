using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> CreateBook(BookDTO bookDto)
        {
            var book = await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDTO bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }
            var book = await _bookService.UpdateBookAsync(bookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpGet("with-authors")]
        public async Task<ActionResult<IEnumerable<BookWithAuthorDto>>> GetBooksWithAuthors()
        {
            var booksWithAuthors = await _bookService.GetBooksWithAuthorsAsync();
            return Ok(booksWithAuthors);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<BookDetailsWithAllRelationsDto>> GetBookWithDetails(int id)
        {
            var bookWithDetail = await _bookService.GetBookWithDetailsAsync(id);
            if (bookWithDetail == null)
            {
                return NotFound();
            }
            return Ok(bookWithDetail);
        }
    }
}