// <copyright file="IBookRepository.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Collections.Generic;
using AspNetSandbox.Models;

namespace AspNetSandbox
{
    /// <summary>Interface for Books.</summary>
    public interface IBookRepository
    {
        /// <summary>Gets this instance.</summary>
        /// <returns>
        ///   <para>List of book.</para>
        /// </returns>
        List<Book> Get();

        /// <summary>Removes the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        void RemoveBookById(int id);

        /// <summary>Gets the specified book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>If id found, returns the book, otherwise returns null.</returns>
        Book Get(int id);

        /// <summary>Adds the book to the instance.</summary>
        /// <param name="newBook">
        ///   <para>
        /// The new Book.
        /// </para>
        /// </param>
        void AddBook(Book newBook);

        /// <summary>Updates the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newBook">The new Book.</param>
        void UpdateBookById(int id, Book newBook);
    }
}