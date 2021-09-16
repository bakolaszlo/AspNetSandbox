// <copyright file="DbBooksRepository.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using AspNetSandbox.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Services
{
    /// <summary>
    ///   <para>DB repository for book.</para>
    /// </summary>
    public class DbBooksRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        /// <summary>Initializes a new instance of the <see cref="DbBooksRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public DbBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Adds the book to the instance.</summary>
        /// <param name="newBook">The new Book.</param>
        public void AddBook(Book newBook)
        {
            context.Add(newBook);
            context.SaveChanges();
        }

        /// <summary>Gets this instance.</summary>
        /// <returns>List of book.</returns>
        public List<Book> Get()
        {
            return context.Book.ToList();
        }

        /// <summary>Gets the specified book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>If id found, returns the book, otherwise returns null.</returns>
        public Book Get(int id)
        {
            var book = context.Book
                .FirstOrDefault(m => m.Id == id);
            return book;
        }

        /// <summary>Removes the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void RemoveBookById(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        /// <summary>Updates the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newBook">The new Book.</param>
        public void UpdateBookById(int id, Book newBook)
        {
            context.Update(newBook);
            context.SaveChanges();
        }
    }
}
