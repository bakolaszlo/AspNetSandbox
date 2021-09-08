// <copyright file="IBooksService.cs" company="P33">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System.Collections.Generic;

    /// <summary>Interface for Books.</summary>
    public interface IBooksService
    {
        /// <summary>Removes the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        void RemoveBookById(int id);

        /// <summary>Gets this instance.</summary>
        /// <returns>
        ///   <para>IEnumerable for type Book.</para>
        /// </returns>
        IEnumerable<Book> Get();

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