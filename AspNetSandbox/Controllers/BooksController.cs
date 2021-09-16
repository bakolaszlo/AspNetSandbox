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
using AutoMapper;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="repository"> Singleton Interface. </param>
        /// <param name="hubContext"></param>
        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        /// <summary>Gets the whole instance of books.</summary>
        /// <returns>IEnumerable for Book object.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var exposedRepository = repository.Get();
            var mappedRepository = mapper.Map<List<ReadBookDto>>(exposedRepository);
            return Ok(mappedRepository);
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
                var mapped = mapper.Map<ReadBookDto>(book);
                return Ok(mapped);
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>Add a new book.</summary>
        /// <param name="bookDto">The new Book.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookDto bookDto)
        {

            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBook(book);
                hubContext.Clients.All.SendAsync("BookCreated", bookDto);
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
