using Library.API.Data.Models;
using LibraryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll() => _context.Books.ToList();

        public Book Add(Book newBook)
        {
            newBook.Id = Guid.NewGuid();
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook;
        }

        public Book GetById(Guid id) => _context.Books.FirstOrDefault(a => a.Id == id);

        public void Remove(Guid id)
        {
            var existing = _context.Books.First(a => a.Id == id);
            _context.Books.Remove(existing);
            _context.SaveChanges();
        }
    }
}