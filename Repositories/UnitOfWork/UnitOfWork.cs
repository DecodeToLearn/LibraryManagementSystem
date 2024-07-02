using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Repositories.Abstract;
using LibraryManagementSystem.Repositories.Concrete;

namespace LibraryManagementSystem.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
    private readonly LibraryContext _context;

    public UnitOfWork(LibraryContext context)
    {
        _context = context;
        Books = new BookRepository(_context);
        Authors = new AuthorRepository(_context);
    }

    public IBookRepository Books { get; private set; }
    public IAuthorRepository Authors { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }   
    }
}