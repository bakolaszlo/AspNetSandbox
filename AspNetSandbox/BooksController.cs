﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private Book[] books;
        public BooksController()
        {
            books = new Book[2];
            books[0] = new Book
            {
                Id = 1,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            };

            books[1] = new Book
            {
                Id = books[0].Id + 1,
                Title = "Az isteni formula",
                Language = "Hungarian",
                Author = "José Rodrigues dos Santos"
            };

        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        private bool SomeFunction(Book book)
        {
            return book.Id == 1;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return books.Single(SomeFunction);
        }

        
        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
