using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Services
{
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context; 

        public DbBooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book newBook)
        {
            _context.Add(newBook);
            _context.SaveChanges();
        }

        public List<Book> Get()
        {
            return _context.Book.ToList();
        }

        public Book Get(int id)
        {
            var book = _context.Book
                .FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void RemoveBookById(int id)
        {
            var book = _context.Book.Find(id);
            _context.Book.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateBookById(int id, Book newBook)
        {
            _context.Update(newBook);
            _context.SaveChanges();
        }
    }
}
