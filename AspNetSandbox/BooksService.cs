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
                return books.Single(_ => _.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public void AddBook(Book newBook)
        {
            newBook.Id = bookIdCounter++;
            books.Add(newBook);
        }

        public void UpdateBookById(int id, Book newBook)
        {
            newBook.Id = id;

            Book toReplace = Get(id);

            if(toReplace!=null)
            {
                int index = books.FindIndex(_ => _.Id == id);
                books[index] = newBook;
            }
        }

        public void RemoveBookById(int id)
        {
            books.Remove(Get(id));
        }
    }
}
