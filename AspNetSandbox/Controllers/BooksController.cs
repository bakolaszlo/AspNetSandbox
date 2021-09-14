// <copyright file="BooksController.cs" company="P33">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetSandbox.Data;
    using AspNetSandbox.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>The main controller for the Book api communication.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
    	private readonly ApplicationDbContext _context;
        private readonly IBookRepository booksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="context"> Singleton Interface. </param>
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>Gets the whole instance of books.</summary>
        /// <returns>IEnumerable for Book object.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Book.ToListAsync());
        }

        /// <summary>Gets the specified Book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
            	var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Post([FromBody] Book newBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newBook);
                await _context.SaveChangesAsync();
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
             _context.Update(updatedBook);
             await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>Deletes the specified Book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
