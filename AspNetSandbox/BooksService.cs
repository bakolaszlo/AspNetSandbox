// <copyright file="BooksService.cs" company="P33">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>Service for BooksController.</summary>
    public class BooksService : IBooksService
    {
        private List<Book> books;
        private int bookIdCounter = 1;

        /// <summary>Initializes a new instance of the <see cref="BooksService" /> class.</summary>
        public BooksService()
        {
            books = new List<Book>();
            books.Add(
            new Book
            {
                Id = bookIdCounter++,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos",
            });

            books.Add(new Book
            {
                Id = bookIdCounter++,
                Title = "Az isteni formula2",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos",
            });
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>IEnumerable of type Book.</returns>
        public IEnumerable<Book> Get()
        {
            return books;
        }

        /// <summary>Gets the specified Book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
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

        /// <summary>Adds the book.</summary>
        /// <param name="newBook">The new book.</param>
        public void AddBook(Book newBook)
        {
            newBook.Id = bookIdCounter++;
            books.Add(newBook);
        }

        /// <summary>Updates the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newBook">The new book.</param>
        public void UpdateBookById(int id, Book newBook)
        {
            newBook.Id = id;

            Book toReplace = Get(id);

            if (toReplace != null)
            {
                int index = books.FindIndex(_ => _.Id == id);
                books[index] = newBook;
            }
        }

        /// <summary>Removes the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void RemoveBookById(int id)
        {
            books.Remove(Get(id));
        }
    }
}
