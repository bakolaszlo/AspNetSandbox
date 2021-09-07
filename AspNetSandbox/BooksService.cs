using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        private int bookIdCounter = 1;

        public BooksService()
        {
            books = new List<Book>();
            books.Add(
            new Book
            {
                Id = bookIdCounter++,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });

            books.Add(new Book
            {
                Id = bookIdCounter++,
                Title = "Az isteni formula2",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            });
        }

        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            try
            {
                return books.Single(book => book.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public void AddBook(Book value)
        {
            value.Id = bookIdCounter++;
            books.Add(value);
        }

        public void UpdateBookById(int id, Book value)
        {
            value.Id = id;

            int index = books.FindIndex(book => book.Id == id);

            Book toReplace = Get(id);

            if(toReplace!=null)
            {
                books[index] = value;
            }
        }

        public void DeleteBookById(int id)
        {
            books.Remove(Get(id));
        }
    }
}
