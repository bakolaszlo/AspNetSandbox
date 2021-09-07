using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksService
    {
        void RemoveBookById(int id);
        IEnumerable<Book> Get();
        Book Get(int id);
        void AddBook(Book value);
        void UpdateBookById(int id, Book value);
    }
}