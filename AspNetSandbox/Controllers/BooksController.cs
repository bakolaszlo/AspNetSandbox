// <copyright file="BooksController.cs" company="P33">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Data;
using AspNetSandbox.Dtos;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox
{
    /// <summary>The main controller for the Book api communication.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;


        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="repository"> Singleton Interface. </param>
        /// <param name="hubContext"></param>
        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext)
        {
            this.repository = repository;
            this.hubContext = hubContext;
        }

        /// <summary>Gets the whole instance of books.</summary>
        /// <returns>IEnumerable for Book object.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(repository.Get());
        }

        /// <summary>Gets the specified Book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var book = repository.Get(id);
                return Ok(book);
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>Add a new book.</summary>
        /// <param name="newBook">The new Book.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookDto newBook)
        {

            if (ModelState.IsValid)
            {
                repository.AddBook(newBook);
                hubContext.Clients.All.SendAsync("BookCreated", newBook);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>Updates a book content, by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updatedBook">New Book content.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book updatedBook)
        {
            repository.UpdateBookById(id, updatedBook);
            return Ok();
        }

        /// <summary>Deletes the specified Book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            repository.RemoveBookById(id);
            return Ok();
        }
    }
}
