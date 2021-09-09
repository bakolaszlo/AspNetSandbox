// <copyright file="BooksController.cs" company="P33">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetSandbox.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>The main controller for the Book api communication.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="booksService"> Singleton Interface. </param>
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        /// <summary>Gets the whole instance of books.</summary>
        /// <returns>IEnumerable for Book object.</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return booksService.Get();
        }

        /// <summary>Gets the specified Book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(booksService.Get(id));
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>Add a new book.</summary>
        /// <param name="newBook">The new Book.</param>
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            booksService.AddBook(newBook);
        }

        /// <summary>Updates a book content, by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updatedBook">New Book content.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book updatedBook)
        {
            booksService.UpdateBookById(id, updatedBook);
        }

        /// <summary>Deletes the specified Book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            booksService.RemoveBookById(id);
        }
    }
}
